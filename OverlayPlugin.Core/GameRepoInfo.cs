using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.55a
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x038d;
        public static readonly int ActorSetPosOpcode = 0x03df;
        public static readonly int BattleTalk2Opcode = 0x02ad;
        public static readonly int CEDirectorOpcode = 0x0092;
        public static readonly int CountdownOpcode = 0x0322;
        public static readonly int CountdownCancelOpcode = 0x01A9;
        public static readonly int MapEffectOpcode = 0x00BC;
        public static readonly int NpcYellOpcode = 0x0328;
        public static readonly int RSVDataOpcode = 0x03D3;
        public static readonly int MapEffect4Opcode = 0x03D9;
        public static readonly int MapEffect8Opcode = 0x030C;
        public static readonly int MapEffect12Opcode = 0x0366;
    }
}
