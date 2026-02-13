using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.41a
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x0192;
        public static readonly int ActorSetPosOpcode = 0x00B2;
        public static readonly int BattleTalk2Opcode = 0x018c;
        public static readonly int CountdownOpcode = 0x01E2;
        public static readonly int CountdownCancelOpcode = 0x0149;
        public static readonly int CEDirectorOpcode = 0x0256;
        public static readonly int MapEffectOpcode = 0x031C;
        public static readonly int MapEffect4Opcode = 0x01A4;
        public static readonly int MapEffect8Opcode = 0x00CC;
        public static readonly int MapEffect12Opcode = 0x03D4;
        public static readonly int RSVDataOpcode = 0x0201;
        public static readonly int NpcYellOpcode = 0x0290;
    }
}
