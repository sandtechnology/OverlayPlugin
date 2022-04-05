using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Web;
using Advanced_Combat_Tracker;
using SharpCompress.Archives.Zip;
using Newtonsoft.Json.Linq;
using RainbowMage.OverlayPlugin.Updater;

namespace RainbowMage.OverlayPlugin
{
    public partial class WSConfigPanel : UserControl
    {
        const string MKCERT_DOWNLOAD = "https://github.com/FiloSottile/mkcert/releases/download/v1.4.3/mkcert-v1.4.3-windows-amd64.exe";
        const string NGROK_DOWNLOAD_IDX = "https://ngrok.com/download";

        IPluginConfig _config;
        WSServer _server;
        PluginMain _plugin;
        Registry _registry;
        Process _ngrok;
        string _ngrokPrefix = null;

        private enum TunnelStatus
        {
            Unknown,
            Inactive,
            Downloading,
            Launching,
            Active,
            Error
        };

        public WSConfigPanel(TinyIoCContainer container)
        {
            InitializeComponent();

            _config = container.Resolve<IPluginConfig>();
            _server = container.Resolve<WSServer>();
            _plugin = container.Resolve<PluginMain>();
            _registry = container.Resolve<Registry>();


            ipTxt.Text = _config.WSServerIP;
            portTxt.Text = "" + _config.WSServerPort;
            sslBox.Checked = _config.WSServerSSL;
            sslBox.Enabled = _server.IsSSLPossible();

            for (var i = 0; i < regionCb.Items.Count; i++)
            {
                if ((string) regionCb.Items[i] == _config.TunnelRegion)
                {
                    regionCb.SelectedIndex = i;
                    break;
                }
            }

            UpdateStatus(null, new WSServer.StateChangedArgs(_server.IsRunning(), _server.IsFailed()));
            _server.OnStateChanged += UpdateStatus;

            UpdateTunnelStatus(TunnelStatus.Inactive);

            lblUrlConfidentWarning.Visible = false;
        }

        public void Stop()
        {
            if (_ngrok != null && !_ngrok.HasExited)
                _ngrok.Kill();
        }

        private void UpdateStatus(object sender, WSServer.StateChangedArgs e)
        {
            startBtn.Enabled = true;
            stopBtn.Enabled = false;

            if (e.Running)
            {
                statusLabel.Text = "运行中";
                statusLabel.ForeColor = Color.ForestGreen;

                startBtn.Enabled = false;
                stopBtn.Enabled = true;
            }
            else if (e.Failed)
            {
                statusLabel.Text = "开启失败";
                statusLabel.ForeColor = Color.DarkRed;
            }
            else
            {
                statusLabel.Text = "已停止";
                statusLabel.ForeColor = Color.Gray;
            }
        }

        private void UpdateTunnelStatus(TunnelStatus status)
        {
            switch (status)
            {
                case TunnelStatus.Unknown:
                    simpStatusLbl.Text = "未知";
                    simpStatusLbl.ForeColor = Color.Gray;

                    simpStartBtn.Enabled = false;
                    simpStopBtn.Enabled = false;
                    break;

                case TunnelStatus.Downloading:
                    simpStatusLbl.Text = "下载客户端...";
                    simpStatusLbl.ForeColor = Color.CornflowerBlue;

                    simpStartBtn.Enabled = false;
                    simpStopBtn.Enabled = false;
                    break;

                case TunnelStatus.Launching:
                    simpStatusLbl.Text = "启动中...";
                    simpStatusLbl.ForeColor = Color.CornflowerBlue;

                    simpStartBtn.Enabled = false;
                    simpStopBtn.Enabled = false;
                    break;

                case TunnelStatus.Active:
                    simpStatusLbl.Text = "运行中";
                    simpStatusLbl.ForeColor = Color.ForestGreen;

                    simpStartBtn.Enabled = false;
                    simpStopBtn.Enabled = true;
                    break;

                case TunnelStatus.Inactive:
                    simpStatusLbl.Text = "停止";
                    simpStatusLbl.ForeColor = Color.Gray;

                    simpStartBtn.Enabled = true;
                    simpStopBtn.Enabled = false;
                    break;

                case TunnelStatus.Error:
                    simpStatusLbl.Text = "出现错误";
                    simpStatusLbl.ForeColor = Color.DarkRed;

                    simpStartBtn.Enabled = true;
                    simpStopBtn.Enabled = false;
                    break;
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            _config.WSServerRunning = true;
            _server.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            _config.WSServerRunning = false;
            _server.Stop();
        }

        private void genSslBtn_Click(object sender, EventArgs e)
        {
            genSslBtn.Enabled = false;
            logDisplay.Text = "获取SSL证书中，请等待...\r\n";
            
            Task.Run(GenSsl);
        }

        private void GenSsl()
        {
            try
            {
                var mkcertPath = Path.Combine(_plugin.PluginDirectory, "mkcert.exe");

                if (!File.Exists(mkcertPath))
                {
                    logDisplay.AppendText("下载mkcert...\r\n");

                    try
                    {
                        HttpClientWrapper.Get(MKCERT_DOWNLOAD, new Dictionary<string, string>(), mkcertPath, null, false);
                    }
                    catch (Exception e)
                    {
                        logDisplay.AppendText(string.Format("\n失败: {0}", e));
                        genSslBtn.Enabled = true;
                        return;
                    }
                }

                logDisplay.AppendText("安装证书...\r\n");
                if (!RunLogCmd(mkcertPath, "-install"))
                {
                    logDisplay.AppendText("\r\n失败！\r\n");
                    genSslBtn.Enabled = true;
                    return;
                }

                logDisplay.AppendText("获取证书...\r\n");
                if (!RunLogCmd(mkcertPath, string.Format("-pkcs12 -p12-file \"{0}\" localhost 127.0.0.1 ::1", _server.GetCertPath())))
                {
                    logDisplay.AppendText("\r\n失败！\r\n");
                    genSslBtn.Enabled = true;
                    return;
                }

                logDisplay.AppendText("\r\n完成。\r\n");

                sslBox.Enabled = _server.IsSSLPossible();
                sslBox.Checked = sslBox.Enabled;
                _config.WSServerSSL = sslBox.Enabled;
                genSslBtn.Enabled = true;
            }
            catch (Exception e)
            {
                logDisplay.AppendText(string.Format("\r\n出现异常: {0}", e));
                genSslBtn.Enabled = true;
            }
        }

        private bool RunLogCmd(string file, string args)
        {
            using (var p = new Process())
            {
                p.StartInfo.FileName = file;
                p.StartInfo.Arguments = args;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;

                DataReceivedEventHandler showLine = (sender, e) =>
                {
                    if (e.Data != null) logDisplay.AppendText(e.Data.Replace("\n", "\r\n") + "\r\n");
                };

                p.OutputDataReceived += showLine;
                p.ErrorDataReceived += showLine;

                p.Start();
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                p.WaitForExit(10000);

                return p.ExitCode == 0;
            }
        }

        private void sslBox_CheckedChanged(object sender, EventArgs e)
        {
            _config.WSServerSSL = sslBox.Checked;
        }

        private void portTxt_Leave(object sender, EventArgs e)
        {
            var valid = true;
            int port = 0;
            try
            {
                port = int.Parse(portTxt.Text);
            }
            catch
            {
                valid = false;
            }

            if (valid && (port < 1 || port > 65535))
            {
                valid = false;
            }

            if (valid)
            {
                _config.WSServerPort = port;
            }
            else
            {
                MessageBox.Show(
                    string.Format("{0} 端口不正确，范围应为1-65535.", portTxt.Text),
                    "端口不正确",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        private void ipTxt_Leave(object sender, EventArgs e)
        {
            IPAddress addr = null;
            if (ipTxt.Text == "*" || IPAddress.TryParse(ipTxt.Text, out addr))
            {
                _config.WSServerIP = ipTxt.Text;
            }
            else
            {
                MessageBox.Show(
                    string.Format("{0} 不是IP地址", ipTxt.Text),
                    "IP地址错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
            }
        }

        public void RebuildOverlayOptions()
        {
            cbOverlay.Items.Clear();

            foreach (var preset in _registry.OverlayPresets)
            {
                cbOverlay.Items.Add(new
                {
                    label = preset.Name,
                    preset
                });
            }
        }

        private void cbOverlay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbOverlay.SelectedIndex == -1) return;

            var item = cbOverlay.Items[cbOverlay.SelectedIndex];
            var preset = (IOverlayPreset) item.GetType().GetProperty("preset").GetValue(item);
            if (preset == null) return;

            var hostUrl = "";
            if (_ngrokPrefix != null)
            {
                hostUrl += _ngrokPrefix;
            } else
            {
                if (_config.WSServerSSL)
                {
                    hostUrl += "wss://";
                } else
                {
                    hostUrl += "ws://";
                }

                if (_config.WSServerIP == "0.0.0.0")
                {
                    hostUrl += "127.0.0.1";
                } else
                {
                    hostUrl += _config.WSServerIP;
                }
                hostUrl += ":" + _config.WSServerPort;
            }

#if DEBUG
            var resourcesPath = "file:///" + _plugin.PluginDirectory.Replace('\\', '/') + "/libs/resources";
#else
            var resourcesPath = "file:///" + _plugin.PluginDirectory.Replace('\\', '/') + "/resources";
#endif

            var url = preset.Url.Replace("\\", "/").Replace("%%", resourcesPath);
            UriBuilder uri = new UriBuilder(url);
            NameValueCollection query_params = HttpUtility.ParseQueryString(uri.Query);

            if (preset.Supports.Contains("modern"))
            {
                query_params.Add("OVERLAY_WS", hostUrl + "/ws");
            } else if (preset.Supports.Contains("actws"))
            {
                query_params.Add("HOST_PORT", hostUrl + "/");
            } else
            {
                url = "";
            }

            uri.Query = HttpUtility.UrlDecode(query_params.ToString());

            if ((uri.Port == 443 && uri.Scheme == "https") || (uri.Port == 80 && uri.Scheme == "http"))
            {
                uri.Port = -1;
            }

            txtOverlayUrl.Text = (url != "") ? uri.ToString() : url;
        }

        private void txtOverlayUrl_Click(object sender, EventArgs e)
        {
            txtOverlayUrl.SelectAll();
            txtOverlayUrl.Copy();
        }

        private class ShowLineArgs : EventArgs
        {
            public string Data { get; private set; }
            public ShowLineArgs(string d)
            {
                Data = d;
            }
        }

        private void simpStartBtn_Click(object sender, EventArgs e)
        {
            simpStartBtn.Enabled = false;

            Task.Run(() => {
                try
                {
                    var ngrokPath = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "ngrok-" + (Environment.Is64BitOperatingSystem ? "x64" : "x86") + ".exe");
                    if (!File.Exists(ngrokPath))
                    {
                        if (!FetchNgrok(ngrokPath)) return;
                    }

                    UpdateTunnelStatus(TunnelStatus.Launching);

                    if (_ngrok != null && !_ngrok.HasExited)
                    {
                        simpLogBox.AppendText("检测到遗留的 ngrok 进程。清理中...\r\n");
                        _ngrok.Kill();
                        _ngrok = null;
                    }

                    // Enforce sensible settings
                    ipTxt.Text = "127.0.0.1";
                    sslBox.Checked = false;

                    _config.WSServerIP = "127.0.0.1";
                    _config.WSServerSSL = false;

                    if (_config.WSServerPort < 1024)
                    {
                        portTxt.Text = "10501";
                        _config.WSServerPort = 10501;
                    }

                    simpLogBox.AppendText("启动WS服务...\r\n");
                    _config.WSServerRunning = true;
                    _server.Start();

                    simpLogBox.AppendText("启动ngrok...\r\n");

                    var region = _config.TunnelRegion;
                    if (region == null)
                    {
                        region = "us";
                    } else
                    {
                        region = region.Split(' ')[0];
                    }

                    var config = @"
region: " + region + @"
console_ui: false
web_addr: 127.0.0.1:" + (_config.WSServerPort + 1) + @"

tunnels:
    wsserver:
        proto: http
        addr: 127.0.0.1:" + _config.WSServerPort + @"
        inspect: false
        bind_tls: true
    ";
                    var ngrokConfigPath = Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "ngrok.yml");
                    File.WriteAllText(ngrokConfigPath, config);

                    var p = new Process();
                    p.StartInfo.FileName = ngrokPath;
                    p.StartInfo.Arguments = "start -config=\"" + ngrokConfigPath + "\" wsserver";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.RedirectStandardOutput = true;

                    DataReceivedEventHandler showLine = (_, ev) =>
                    {
                        if (ev.Data != null) simpLogBox.AppendText(ev.Data.Replace("\n", "\r\n") + "\r\n");
                    };

                    p.OutputDataReceived += showLine;
                    p.ErrorDataReceived += showLine;

                    p.Start();
                    p.BeginOutputReadLine();
                    p.BeginErrorReadLine();

                    if (p.WaitForExit(3000))
                    {
                        simpLogBox.AppendText("ngrok崩溃了！\r\n");
                        UpdateTunnelStatus(TunnelStatus.Error);
                        return;
                    }

                    _ngrok = p;

                    var apiUrl = "http://127.0.0.1:" + (_config.WSServerPort + 1) + "/api/tunnels";
                    var headers = new Dictionary<string, string>()
                    {
                        { "Content-Type", "application/json" },
                    };

                    string data = null;
                    while (true)
                    {
                        try
                        {
                            data = HttpClientWrapper.Get(apiUrl, headers, null, null, false);
                            break;
                        } catch(CurlException ex)
                        {
                            if (!ex.Retry)
                            {
                                simpLogBox.AppendText(string.Format("错误: {0}\r\n", ex));
                                UpdateTunnelStatus(TunnelStatus.Error);
                                return;
                            } else
                            {
                                Thread.Sleep(500);
                            }
                        } catch (Exception ex)
                        {
                            simpLogBox.AppendText(string.Format("失败: {0}\r\n", ex));
                            UpdateTunnelStatus(TunnelStatus.Error);
                            return;
                        }
                    }

                    var tunnels = JObject.Parse(data);
                    var done = false;
                    foreach (var tun in tunnels["tunnels"])
                    {
                        if (tun["name"] != null && tun["name"].ToString() == "wsserver" && tun["public_url"] != null)
                        {
                            _ngrokPrefix = tun["public_url"].ToString().Replace("https://", "wss://");
                            
                            // Update the generated URL box
                            cbOverlay_SelectedIndexChanged(null, null);
                            done = true;
                            break;
                        }
                    }

                    if (done)
                    {
                        simpLogBox.AppendText("Done!\r\n");
                        simpLogBox.AppendText("\r\n#############################################\r\n请使用下面的URL生成器：\r\n\r\n");
                        simpLogBox.AppendText("\r\n如果你知道在做什么或者在使用未在此处列出的悬浮窗, 这里是一些请求用的字段:\r\n");
                        simpLogBox.AppendText("\r\n    ?HOST_PORT=" + _ngrokPrefix + "\r\n    ?OVERLAY_WS=" + _ngrokPrefix + "/ws\r\n");
                        simpLogBox.AppendText("#############################################\r\n");

                        UpdateTunnelStatus(TunnelStatus.Active);

                        p.Exited += (_, ev) =>
                        {
                            UpdateTunnelStatus(TunnelStatus.Error);
                        };
                    } else
                    {
                        simpLogBox.AppendText("失败!\r\n");
                        UpdateTunnelStatus(TunnelStatus.Error);
                    }
                } catch (Exception ex)
                {
                    simpLogBox.AppendText(string.Format("\r\n未捕获的异常: {0}\r\n\r\n", ex));
                    UpdateTunnelStatus(TunnelStatus.Error);
                }
            });
        }

        private bool NgrokProgressCallback(long resumed, long dltotal, long dlnow, long ultotal, long ulnow)
        {
            var percent = ((float)resumed + dlnow) / ((float)resumed + dltotal);
            var dlMib = ((resumed + dlnow) / 1024 / 1024);
            var totalMib = ((resumed + dltotal) / 1024 / 1024);

            // Avoid NaN%
            if (dlMib == 0) percent = 0;

            var lines = simpLogBox.Lines;
            lines[lines.Length - 1] = Math.Round(percent * 100, 2) + "% (" + dlMib + " MiB / " + totalMib + " MiB)";
            simpLogBox.Lines = lines;

            return false;
        }

        private bool FetchNgrok(string ngrokPath)
        {
            try
            {
                UpdateTunnelStatus(TunnelStatus.Downloading);

                simpLogBox.AppendText("获取最新的ngrok客户端...\r\n");
                string dlPage;
                try
                {
                    dlPage = HttpClientWrapper.Get(NGROK_DOWNLOAD_IDX);
                } catch (Exception e)
                {
                    simpLogBox.AppendText(string.Format("\r\n错误: {0}\r\n\r\n", e));
                    return false;
                }

                var arch = Environment.Is64BitOperatingSystem ? "amd64" : "386";
                // <a id="dl-windows-amd64" href="https://bin.equinox.io/c/4VmDzA7iaHb/ngrok-stable-windows-amd64.zip" class="download-btn"
                var match = Regex.Match(dlPage, " href=\"(https://bin.equinox.io/c/[^/]+/ngrok-stable-windows-" + arch + "\\.zip)\"");
                if (match == Match.Empty)
                {
                    simpLogBox.AppendText("无法找到下载链接！请告知开发者。\r\n");
                    return false;
                }

                simpLogBox.AppendText("下载ngrok客户端...\r\n");
                try
                {
                    HttpClientWrapper.Get(match.Groups[1].Captures[0].Value, new Dictionary<string, string>(), ngrokPath + ".zip", NgrokProgressCallback, false);
                }
                catch (Exception e)
                {
                    simpLogBox.AppendText(string.Format("\r\n错误: {0}\r\n\r\n", e));
                    return false;
                }

                simpLogBox.AppendText("\r\n解压ngrok客户端...\r\n");
                try
                {
                    using (var archive = ZipArchive.Open(ngrokPath + ".zip"))
                    using (var reader = archive.ExtractAllEntries())
                    {
                        while (reader.MoveToNextEntry())
                        {
                            if (reader.Entry.Key == "ngrok.exe")
                            {
                                using (var writer = File.OpenWrite(ngrokPath))
                                {
                                    reader.WriteEntryTo(writer);
                                }
                                break;
                            }
                        }
                    }

                    File.Delete(ngrokPath + ".zip");
                } catch (Exception e)
                {
                    simpLogBox.AppendText(string.Format("\r\n{0}\r\n\r\n", e));
                }

                if (!File.Exists(ngrokPath))
                {
                    simpLogBox.AppendText("\r\n解压失败!\r\n");
                    return false;
                }

                return true;
            }
            catch (Exception e)
            {
                simpLogBox.AppendText(string.Format("\r\n异常: {0}\r\n\r\n", e));
                return false;
            }
        }

        private void simpStopBtn_Click(object sender, EventArgs e)
        {
            try
            {
                simpLogBox.AppendText("\r\n关闭隧道...\r\n");

                if (_ngrok != null && !_ngrok.HasExited)
                {
                    _ngrok.Kill();
                    _ngrok = null;
                }

                _ngrokPrefix = null;

                simpLogBox.AppendText("关闭WS服务器...\r\n");
                if (_server.IsRunning())
                {
                    _server.Stop();
                }

                simpLogBox.AppendText("完成!\r\n");
                UpdateTunnelStatus(TunnelStatus.Inactive);
            } catch (Exception ex)
            {
                simpLogBox.AppendText(string.Format("\r\n错误: {0}\r\n\r\n", ex));
                UpdateTunnelStatus(TunnelStatus.Error);
            }
        }

        private void regionCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _config.TunnelRegion = (string) regionCb.SelectedItem;
        }
    }
}
