﻿using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RainbowMage.OverlayPlugin.Updater;

namespace RainbowMage.OverlayPlugin.NetworkProcessors
{
    class OverlayPluginLogLines
    {
        public OverlayPluginLogLines(TinyIoCContainer container)
        {
            container.Register(new OverlayPluginLogLineConfig(container));
            container.Register(new LineMapEffect(container));
            container.Register(new LineFateControl(container));
            container.Register(new LineCEDirector(container));
        }
    }

    class OverlayPluginLogLineConfig
    {
        private TinyIoCContainer container;
        private ILogger logger;
        private Dictionary<string, OpcodeConfigEntry> opcodes = new Dictionary<string, OpcodeConfigEntry>();
        public OverlayPluginLogLineConfig(TinyIoCContainer container)
        {
            this.container = container;
            logger = container.Resolve<ILogger>();
            opcodes.Add("CEDirector", new OpcodeConfigEntry { opcode = (uint)Opcodes.CEDirector, size = 16 });
            opcodes.Add("MapEffect", new OpcodeConfigEntry { opcode = (uint)Opcodes.MapEffect, size = 11 });
        }

        public IOpcodeConfigEntry this[string name]
        {
            get
            {
                OpcodeConfigEntry entry;
                if (opcodes.TryGetValue(name, out entry))
                {
                    return entry;
                }
                else
                {
                    logger.LogError("Unable to recive opcode config for " + name);
                    return null;
                }
            }
        }
    }
    interface IOpcodeConfigEntry
    {
        uint opcode { get; }
        uint size { get; }
    }

    [JsonObject(NamingStrategyType = typeof(Newtonsoft.Json.Serialization.DefaultNamingStrategy))]
    class OpcodeConfigEntry : IOpcodeConfigEntry
    {
        public uint opcode { get; set; }
        public uint size { get; set; }
    }
}