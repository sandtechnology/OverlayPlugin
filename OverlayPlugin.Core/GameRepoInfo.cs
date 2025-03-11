using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.11
        public static readonly Version version = new Version(7, 1);
        public static readonly int ActorMoveOpcode = 0x027A;
        public static readonly int ActorSetPosOpcode = 0x3C6;
        public static readonly int BattleTalk2Opcode = 0x34A;
        public static readonly int CountdownOpcode = 0x210;
        public static readonly int CountdownCancelOpcode = 0x2E1;
        public static readonly int CEDirectorOpcode = 0x0C1;
        public static readonly int MapEffectOpcode = 0x151;
        public static readonly int RSVDataOpcode = 0x1D2;
        public static readonly int NpcYellOpcode = 0x342;
    }
}
