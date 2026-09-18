using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.56a
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x01D9;
        public static readonly int ActorSetPosOpcode = 0x02AE;
        public static readonly int BattleTalk2Opcode = 0x01E1;
        public static readonly int CEDirectorOpcode = 0x031E;
        public static readonly int CountdownOpcode = 0x034E;
        public static readonly int CountdownCancelOpcode = 0x01B9;
        public static readonly int MapEffectOpcode = 0x0198;
        public static readonly int NpcYellOpcode = 0x00DD;
        public static readonly int RSVDataOpcode = 0x00F3;
        public static readonly int MapEffect4Opcode = 0x03AE;
        public static readonly int MapEffect8Opcode = 0x02C7;
        public static readonly int MapEffect12Opcode = 0x0226;
    }
}
