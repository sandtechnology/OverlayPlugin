using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.45a
        public static readonly Version version = new Version(7, 4);
        public static readonly int ActorMoveOpcode = 0x0362;
        public static readonly int ActorSetPosOpcode = 0x01C8;
        public static readonly int BattleTalk2Opcode = 0x02EC;
        public static readonly int CEDirectorOpcode = 0x02F5;
        public static readonly int CountdownOpcode = 0x021A;
        public static readonly int CountdownCancelOpcode = 0x0349;
        public static readonly int MapEffectOpcode = 0x0386;
        public static readonly int NpcYellOpcode = 0x00B4;
        public static readonly int RSVDataOpcode = 0x0378;
        public static readonly int MapEffect4Opcode = 0x0383;
        public static readonly int MapEffect8Opcode = 0x02B6;
        public static readonly int MapEffect12Opcode = 0x022C;
    }
}
