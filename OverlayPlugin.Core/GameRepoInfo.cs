using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.57
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x0217;
        public static readonly int ActorSetPosOpcode = 0x03E0;
        public static readonly int BattleTalk2Opcode = 0x00A2;
        public static readonly int CEDirectorOpcode = 0x020A;
        public static readonly int CountdownOpcode = 0x01A4;
        public static readonly int CountdownCancelOpcode = 0x0173;
        public static readonly int MapEffectOpcode = 0x01A6;
        public static readonly int NpcYellOpcode = 0x0065;
        public static readonly int RSVDataOpcode = 0x0112;
        public static readonly int MapEffect4Opcode = 0x02B4;
        public static readonly int MapEffect8Opcode = 0x0323;
        public static readonly int MapEffect12Opcode = 0x0137;
    }
}
