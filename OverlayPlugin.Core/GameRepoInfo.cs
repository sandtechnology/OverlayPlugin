using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainbowMage.OverlayPlugin
{
    public class GameRepoInfo
    {
        //CN 7.58
        public static readonly Version version = new Version(7, 5);
        public static readonly int ActorMoveOpcode = 0x00AE;
        public static readonly int ActorSetPosOpcode = 0x03A6;
        public static readonly int BattleTalk2Opcode = 0x00EC;
        public static readonly int CEDirectorOpcode = 0x026E;
        public static readonly int CountdownOpcode = 0x025C;
        public static readonly int CountdownCancelOpcode = 0x0089;
        public static readonly int MapEffectOpcode = 0x0097;
        public static readonly int NpcYellOpcode = 0x0345;
        public static readonly int RSVDataOpcode = 0x0252;
        public static readonly int MapEffect4Opcode = 0x0247;
        public static readonly int MapEffect8Opcode = 0x0165;
        public static readonly int MapEffect12Opcode = 0x018A;
    }
}
