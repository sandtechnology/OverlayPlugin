using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.25
        public static readonly Version version = new Version(7, 2);
        public static readonly int ActorMoveOpcode = 0x031A;
        public static readonly int ActorSetPosOpcode = 0x0277;
        public static readonly int BattleTalk2Opcode = 0x00E9;
        public static readonly int CountdownOpcode = 0x027B;
        public static readonly int CountdownCancelOpcode = 0x03A7;
        public static readonly int CEDirectorOpcode = 0x014E;
        public static readonly int MapEffectOpcode = 0x0384;
        public static readonly int MapEffect4Opcode = 0x00E1;
        public static readonly int MapEffect8Opcode = 0x0315;
        public static readonly int MapEffect12Opcode = 0x0362;
        public static readonly int RSVDataOpcode = 0x0182;
        public static readonly int NpcYellOpcode = 0x029C;
    }
}
