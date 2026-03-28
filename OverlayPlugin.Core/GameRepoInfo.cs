using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.45b
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x02B0;
        public static readonly int ActorSetPosOpcode = 0x0085;
        public static readonly int BattleTalk2Opcode = 0x0345;
        public static readonly int CEDirectorOpcode = 0x0224;
        public static readonly int CountdownOpcode = 0x0206;
        public static readonly int CountdownCancelOpcode = 0x0196;
        public static readonly int MapEffectOpcode = 0x02EA;
        public static readonly int NpcYellOpcode = 0x022C;
        public static readonly int RSVDataOpcode = 0x01D1;
        public static readonly int MapEffect4Opcode = 0x02CE;
        public static readonly int MapEffect8Opcode = 0x018E;
        public static readonly int MapEffect12Opcode = 0x01B6;
    }
}
