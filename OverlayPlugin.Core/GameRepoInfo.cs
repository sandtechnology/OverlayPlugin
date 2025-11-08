using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.35
        public static readonly Version version = new Version(7, 3);
        public static readonly int ActorMoveOpcode = 0x00BC;
        public static readonly int ActorSetPosOpcode = 0x00D5;
        public static readonly int BattleTalk2Opcode = 0x028D;
        public static readonly int CountdownOpcode = 0x0391;
        public static readonly int CountdownCancelOpcode = 0x03B3;
        public static readonly int CEDirectorOpcode = 0x0364;
        public static readonly int MapEffectOpcode = 0x01B2;
        public static readonly int MapEffect4Opcode = 0x025C;
        public static readonly int MapEffect8Opcode = 0x0239;
        public static readonly int MapEffect12Opcode = 0x0109;
        public static readonly int RSVDataOpcode = 0x01FE;
        public static readonly int NpcYellOpcode = 0x015F;
    }
}
