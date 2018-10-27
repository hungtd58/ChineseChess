using System;
using System.Collections;

namespace ChineseChess
{
    public class ChessBoard
    {
        public static bool CO_UP = false;

        public static readonly int[,] GameBoardEmpty = {
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
        };
        public static readonly int[,] GameBoardOrigin = {
            /*0*/{Chess.XE_1,      0, 0,             Chess.TOT_1,    0, 0, Chess.TOT_2,      0,              0, Chess.XE_2     },
            /*1*/{Chess.MA_1,      0, Chess.PHAO_1,  0,              0, 0, 0,                Chess.PHAO_2,   0, Chess.MA_2     },
            /*2*/{Chess.TUONG_1,   0, 0,             Chess.TOT_1,    0, 0, Chess.TOT_2,      0,              0, Chess.TUONG_2  },
            /*3*/{Chess.SI_1,      0, 0,             0,              0, 0, 0,                0,              0, Chess.SI_2     },
            /*4*/{Chess.VUA_1,     0, 0,             Chess.TOT_1,    0, 0, Chess.TOT_2,      0,              0, Chess.VUA_2    },
            /*5*/{Chess.SI_1,      0, 0,             0,              0, 0, 0,                0,              0, Chess.SI_2     },
            /*6*/{Chess.TUONG_1,   0, 0,             Chess.TOT_1,    0, 0, Chess.TOT_2,      0,              0, Chess.TUONG_2  },
            /*7*/{Chess.MA_1,      0, Chess.PHAO_1,  0,              0, 0, 0,                Chess.PHAO_2,   0, Chess.MA_2     },
            /*8*/{Chess.XE_1,      0, 0,             Chess.TOT_1,    0, 0, Chess.TOT_2,      0,              0, Chess.XE_2     }
            //      0              1  2              3               4  5  6                 7               8  9
        };

        public static int[] PositionChess = new int[90];
    }
}
