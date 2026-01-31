using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.41
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x013b;
        public static readonly int ActorSetPosOpcode = 0x0202;
        public static readonly int BattleTalk2Opcode = 0x012d;
        public static readonly int CountdownOpcode = 0x0098;
        public static readonly int CountdownCancelOpcode = 0x0371;
        public static readonly int CEDirectorOpcode = 0x00f5;
        public static readonly int MapEffectOpcode = 0x00b6;
        public static readonly int MapEffect4Opcode = 0x03d0;
        public static readonly int MapEffect8Opcode = 0x0398;
        public static readonly int MapEffect12Opcode = 0x0196;
        public static readonly int RSVDataOpcode = 0x0374;
        public static readonly int NpcYellOpcode = 0x02ea;
    }
}
