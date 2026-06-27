using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.51b
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x01ce;
        public static readonly int ActorSetPosOpcode = 0x033e;
        public static readonly int BattleTalk2Opcode = 0x014c;
        public static readonly int CEDirectorOpcode = 0x0377;
        public static readonly int CountdownOpcode = 0x0325;
        public static readonly int CountdownCancelOpcode = 0x030b;
        public static readonly int MapEffectOpcode = 0x0080;
        public static readonly int NpcYellOpcode = 0x01B6;
        public static readonly int RSVDataOpcode = 0x02a0;
        public static readonly int MapEffect4Opcode = 0x0196;
        public static readonly int MapEffect8Opcode = 0x018d;
        public static readonly int MapEffect12Opcode = 0x03d0;
    }
}
