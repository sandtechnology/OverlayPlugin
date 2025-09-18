using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.3
        public static readonly Version version = new Version(7, 3);
        public static readonly int ActorMoveOpcode = 0x012F;
        public static readonly int ActorSetPosOpcode = 0x015F;
        public static readonly int BattleTalk2Opcode = 0x026B;
        public static readonly int CountdownOpcode = 0x0388;
        public static readonly int CountdownCancelOpcode = 0x00EC;
        public static readonly int CEDirectorOpcode = 0x026D;
        public static readonly int MapEffectOpcode = 0x021E;
        public static readonly int MapEffect4Opcode = 0x020A;
        public static readonly int MapEffect8Opcode = 0x00CA;
        public static readonly int MapEffect12Opcode = 0x010D;
        public static readonly int RSVDataOpcode = 0x0224;
        public static readonly int NpcYellOpcode = 0x03D1;
    }
}
