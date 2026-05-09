using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.50a
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x0095;
        public static readonly int ActorSetPosOpcode = 0x01C0;
        public static readonly int BattleTalk2Opcode = 0x028C;
        public static readonly int CEDirectorOpcode = 0x016C;
        public static readonly int CountdownOpcode = 0x033F;
        public static readonly int CountdownCancelOpcode = 0x0300;
        public static readonly int MapEffectOpcode = 0x0338;
        public static readonly int NpcYellOpcode = 0x02A7;
        public static readonly int RSVDataOpcode = 0x01BB;
        public static readonly int MapEffect4Opcode = 0x03A6;
        public static readonly int MapEffect8Opcode = 0x0360;
        public static readonly int MapEffect12Opcode = 0x02D8;
    }
}
