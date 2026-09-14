using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.56
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x0334;
        public static readonly int ActorSetPosOpcode = 0x03a2;
        public static readonly int BattleTalk2Opcode = 0x0155;
        public static readonly int CEDirectorOpcode = 0x0393;
        public static readonly int CountdownOpcode = 0x021e;
        public static readonly int CountdownCancelOpcode = 0x011e;
        public static readonly int MapEffectOpcode = 0x00b1;
        public static readonly int NpcYellOpcode = 0x00CA;
        public static readonly int RSVDataOpcode = 0x0333;
        public static readonly int MapEffect4Opcode = 0x0243;
        public static readonly int MapEffect8Opcode = 0x0085;
        public static readonly int MapEffect12Opcode = 0x00D2;
    }
}
