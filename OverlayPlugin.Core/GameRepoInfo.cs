using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.51a
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x0366;
        public static readonly int ActorSetPosOpcode = 0x0131;
        public static readonly int BattleTalk2Opcode = 0x0298;
        public static readonly int CEDirectorOpcode = 0x013B;
        public static readonly int CountdownOpcode = 0x02B6;
        public static readonly int CountdownCancelOpcode = 0x01DF;
        public static readonly int MapEffectOpcode = 0x03D4;
        public static readonly int NpcYellOpcode = 0x00B3;
        public static readonly int RSVDataOpcode = 0x015F;
        public static readonly int MapEffect4Opcode = 0x0304;
        public static readonly int MapEffect8Opcode = 0x03C1;
        public static readonly int MapEffect12Opcode = 0x0124;
    }
}
