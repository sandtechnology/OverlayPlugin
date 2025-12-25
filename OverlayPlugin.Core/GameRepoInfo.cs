using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.40b
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x02D4;
        public static readonly int ActorSetPosOpcode = 0x01CC;
        public static readonly int BattleTalk2Opcode = 0x00E6;
        public static readonly int CountdownOpcode = 0x03AF;
        public static readonly int CountdownCancelOpcode = 0x00DD;
        public static readonly int CEDirectorOpcode = 0x0305;
        public static readonly int MapEffectOpcode = 0x0223;
        public static readonly int MapEffect4Opcode = 0x03E1;
        public static readonly int MapEffect8Opcode = 0x0144;
        public static readonly int MapEffect12Opcode = 0x00B1;
        public static readonly int RSVDataOpcode = 0x03AB;
        public static readonly int NpcYellOpcode = 0x01DC;
    }
}
