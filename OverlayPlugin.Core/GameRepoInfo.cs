using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.51
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x03B6;
        public static readonly int ActorSetPosOpcode = 0x028F;
        public static readonly int BattleTalk2Opcode = 0x02B4;
        public static readonly int CEDirectorOpcode = 0x03DA;
        public static readonly int CountdownOpcode = 0x0248;
        public static readonly int CountdownCancelOpcode = 0x008F;
        public static readonly int MapEffectOpcode = 0x03B7;
        public static readonly int NpcYellOpcode = 0x0265;
        public static readonly int RSVDataOpcode = 0x020B;
        public static readonly int MapEffect4Opcode = 0x023D;
        public static readonly int MapEffect8Opcode = 0x0241;
        public static readonly int MapEffect12Opcode = 0x0073;
    }
}
