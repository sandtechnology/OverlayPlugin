using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.55
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x0228;
        public static readonly int ActorSetPosOpcode = 0x022a;
        public static readonly int BattleTalk2Opcode = 0x02c3;
        public static readonly int CEDirectorOpcode = 0x0097;
        public static readonly int CountdownOpcode = 0x036b;
        public static readonly int CountdownCancelOpcode = 0x0079;
        public static readonly int MapEffectOpcode = 0x0377;
        public static readonly int NpcYellOpcode = 0x02a1;
        public static readonly int RSVDataOpcode = 0x0384;
        public static readonly int MapEffect4Opcode = 0x0348;
        public static readonly int MapEffect8Opcode = 0x0386;
        public static readonly int MapEffect12Opcode = 0x036c;
    }
}
