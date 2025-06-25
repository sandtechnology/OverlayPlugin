using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.20
        public static readonly Version version = new Version(7, 2);
        public static readonly int ActorMoveOpcode = 0x011C;
        public static readonly int ActorSetPosOpcode = 0x0210;
        public static readonly int BattleTalk2Opcode = 0x01F6;
        public static readonly int CountdownOpcode = 0x0101;
        public static readonly int CountdownCancelOpcode = 0x02A2;
        public static readonly int CEDirectorOpcode = 0x02D4;
        public static readonly int MapEffectOpcode = 0x0149;
        public static readonly int MapEffect4Opcode = 0x0165;
        public static readonly int MapEffect8Opcode = 0x02FE;
        public static readonly int MapEffect12Opcode = 0x0123;
        public static readonly int RSVDataOpcode = 0x0327;
        public static readonly int NpcYellOpcode = 0x01CF;
    }
}
