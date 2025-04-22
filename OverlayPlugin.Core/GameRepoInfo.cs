using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.15
        public static readonly Version version = new Version(7, 1);
        public static readonly int ActorMoveOpcode = 0x022A;
        public static readonly int ActorSetPosOpcode = 0x1AF;
        public static readonly int BattleTalk2Opcode = 0x1EF;
        public static readonly int CountdownOpcode = 0x085;
        public static readonly int CountdownCancelOpcode = 0x398;
        public static readonly int CEDirectorOpcode = 0x176;
        public static readonly int MapEffectOpcode = 0x2F4;
        public static readonly int RSVDataOpcode = 0x0CF;
        public static readonly int NpcYellOpcode = 0x1AE;
    }
}
