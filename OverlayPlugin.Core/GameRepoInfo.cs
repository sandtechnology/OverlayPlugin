using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.40a
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x0266;
        public static readonly int ActorSetPosOpcode = 0x01F8;
        public static readonly int BattleTalk2Opcode = 0x0242;
        public static readonly int CountdownOpcode = 0x026A;
        public static readonly int CountdownCancelOpcode = 0x028A;
        public static readonly int CEDirectorOpcode = 0x0229;
        public static readonly int MapEffectOpcode = 0x0127;
        public static readonly int MapEffect4Opcode = 0x00D3;
        public static readonly int MapEffect8Opcode = 0x00E7;
        public static readonly int MapEffect12Opcode = 0x0397;
        public static readonly int RSVDataOpcode = 0x01D2;
        public static readonly int NpcYellOpcode = 0x013B;
    }
}
