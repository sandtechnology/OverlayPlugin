using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.45
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x0314;
        public static readonly int ActorSetPosOpcode = 0x01f9;
        public static readonly int BattleTalk2Opcode = 0x015f;
        public static readonly int CEDirectorOpcode = 0x0277;
        public static readonly int CountdownOpcode = 0x0362;
        public static readonly int CountdownCancelOpcode = 0x0148;
        public static readonly int MapEffectOpcode = 0x01d8;
        public static readonly int NpcYellOpcode = 0x0168;
        public static readonly int RSVDataOpcode = 0x03a2;
        public static readonly int MapEffect4Opcode = 0x0372;
        public static readonly int MapEffect8Opcode = 0x0352;
        public static readonly int MapEffect12Opcode = 0x0263;
    }
}
