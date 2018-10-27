using System;
using System.Collections;

namespace ChineseChess
{
    public class Chess
    {
        public const int EMPTY = 0;

        public const int TOT_1 = 1;
        public const int PHAO_1 = 2;
        public const int XE_1 = 3;
        public const int MA_1 = 4;
        public const int TUONG_1 = 5;
        public const int SI_1 = 6;
        public const int VUA_1 = 7;

        public const int TOT_2 = -1;
        public const int PHAO_2 = -2;
        public const int XE_2 = -3;
        public const int MA_2 = -4;
        public const int TUONG_2 = -5;
        public const int SI_2 = -6;
        public const int VUA_2 = -7;

        public const int RIVER_1 = 4;
        public const int RIVER_2 = 5;

        public const int MIN_CAPITAL = 3;
        public const int MAX_CAPITAL = 5;
        public const int LINE_CAPITAL_1 = 2;
        public const int LINE_CAPITAL_2 = 7;


        /** ArrayList Position Chess On Board **/

        /** Property **/

        public int id;

        public int value; // > 0 - xanh, < 0 - do

        public int x, y;

        public ArrayList GetPositionCanMove()
        {
            ArrayList rs = new ArrayList();
            switch (value)
            {
                case TOT_1:
                case TOT_2:
                    return GetPositionCanMoveTot();
                case PHAO_1:
                case PHAO_2:
                    return GetPositionCanMovePhao();
                case XE_1:
                case XE_2:
                    return GetPositionCanMoveXe();
                case MA_1:
                case MA_2:
                    return GetPositionCanMoveMa();
                case TUONG_1:
                case TUONG_2:
                    return GetPositionCanMoveTuong();
                case SI_1:
                case SI_2:
                    return GetPositionCanMoveSi();
                case VUA_1:
                case VUA_2:
                    return GetPositionCanMoveVua();
                default:
                    break;
            }
            return rs;
        }

        private ArrayList GetPositionCanMoveVua()
        {
            ArrayList rs = new ArrayList();

            int x1 = x;
            int y1 = y - 1;
            if (IsEmptyOrHasEnemyChessOfVua(x1, y1))
            {
                rs.Add(x1 * 10 + y1);
            }
            int x2 = x;
            int y2 = y + 1;
            if (IsEmptyOrHasEnemyChessOfVua(x2, y2))
            {
                rs.Add(x2 * 10 + y2);
            }
            int x3 = x + 1;
            int y3 = y;
            if (IsEmptyOrHasEnemyChessOfVua(x3, y3))
            {
                rs.Add(x3 * 10 + y3);
            }
            int x4 = x - 1;
            int y4 = y;
            if (IsEmptyOrHasEnemyChessOfVua(x4, y4))
            {
                rs.Add(x4 * 10 + y4);
            }

            return rs;
        }

        private ArrayList GetPositionCanMoveSi()
        {
            ArrayList rs = new ArrayList();

            int x1 = x - 1;
            int y1 = y - 1;
            if (IsEmptyOrHasEnemyChessOfSi(x1, y1))
            {
                rs.Add(x1 * 10 + y1);
            }
            int x2 = x - 1;
            int y2 = y + 1;
            if (IsEmptyOrHasEnemyChessOfSi(x2, y2))
            {
                rs.Add(x2 * 10 + y2);
            }
            int x3 = x + 1;
            int y3 = y - 1;
            if (IsEmptyOrHasEnemyChessOfSi(x3, y3))
            {
                rs.Add(x3 * 10 + y3);
            }
            int x4 = x + 1;
            int y4 = y + 1;
            if (IsEmptyOrHasEnemyChessOfSi(x4, y4))
            {
                rs.Add(x4 * 10 + y4);
            }

            return rs;
        }

        private ArrayList GetPositionCanMoveTuong()
        {
            ArrayList rs = new ArrayList();

            int x1 = x - 1;
            int y1 = y - 1;
            if (IsValidPosition(x1, y1) && ChessBoard.PositionChess[x1 * 10 + y1] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChessOfTuong(x - 2, y - 2))
                {
                    rs.Add((x - 2) * 10 + y - 2);
                }
            }

            int x2 = x + 1;
            int y2 = y - 1;
            if (IsValidPosition(x2, y2) && ChessBoard.PositionChess[x2 * 10 + y2] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChessOfTuong(x + 2, y - 2))
                {
                    rs.Add((x + 2) * 10 + y - 2);
                }
            }

            int x3 = x + 1;
            int y3 = y + 1;
            if (IsValidPosition(x3, y3) && ChessBoard.PositionChess[x3 * 10 + y3] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChessOfTuong(x + 2, y + 2))
                {
                    rs.Add((x + 2) * 10 + y + 2);
                }
            }
            int x4 = x - 1;
            int y4 = y + 1;
            if (IsValidPosition(x4, y4) && ChessBoard.PositionChess[x4 * 10 + y4] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChessOfTuong(x - 2, y + 2))
                {
                    rs.Add((x - 2) * 10 + y + 2);
                }
            }

            return rs;
        }

        private ArrayList GetPositionCanMoveMa()
        {
            ArrayList rs = new ArrayList();

            int xLeft = x - 1;
            int yLeft = y;
            if (IsValidPosition(xLeft, yLeft) && ChessBoard.PositionChess[xLeft * 10 + yLeft] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChess(x - 2, y - 1))
                {
                    rs.Add((x - 2) * 10 + y - 1);
                }
                if (IsEmptyOrHasEnemyChess(x - 2, y + 1))
                {
                    rs.Add((x - 2) * 10 + y + 1);
                }
            }

            int xRight = x + 1;
            int yRight = y;
            if (IsValidPosition(xRight, yRight) && ChessBoard.PositionChess[xRight * 10 + yRight] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChess(x + 2, y - 1))
                {
                    rs.Add((x + 2) * 10 + y - 1);
                }
                if (IsEmptyOrHasEnemyChess(x + 2, y + 1))
                {
                    rs.Add((x + 2) * 10 + y + 1);
                }
            }

            int xUp = x;
            int yUp = y + 1;
            if (IsValidPosition(xUp, yUp) && ChessBoard.PositionChess[xUp * 10 + yUp] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChess(x - 1, y + 2))
                {
                    rs.Add((x - 1) * 10 + y + 2);
                }
                if (IsEmptyOrHasEnemyChess(x + 1, y + 2))
                {
                    rs.Add((x + 1) * 10 + y + 2);
                }
            }
            int xDown = x;
            int yDown = y - 1;
            if (IsValidPosition(xDown, yDown) && ChessBoard.PositionChess[xDown * 10 + yDown] == EMPTY)
            {
                if (IsEmptyOrHasEnemyChess(x - 1, y - 2))
                {
                    rs.Add((x - 1) * 10 + y - 2);
                }
                if (IsEmptyOrHasEnemyChess(x + 1, y - 2))
                {
                    rs.Add((x + 1) * 10 + y - 2);
                }
            }

            return rs;
        }

        private ArrayList GetPositionCanMovePhao()
        {
            ArrayList rs = new ArrayList();

            bool hasValueNotEmpty = false;

            int countL = 1;
            while (true)
            {
                int xTemp = x - countL;
                int yTemp = y;
                int indexCanMoveL = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (!hasValueNotEmpty)
                {
                    if (ChessBoard.PositionChess[indexCanMoveL] == EMPTY)
                    {
                        rs.Add(indexCanMoveL);
                    }
                    else
                    {
                        hasValueNotEmpty = true;
                    }
                }
                else
                {
                    if (ChessBoard.PositionChess[indexCanMoveL] * value < 0)
                    {
                        rs.Add(indexCanMoveL);
                        break;
                    }
                    else if (ChessBoard.PositionChess[indexCanMoveL] != EMPTY)
                    {
                        break;
                    }
                }

                countL++;
            }

            hasValueNotEmpty = false;

            int countR = 1;
            while (true)
            {
                int xTemp = x + countR;
                int yTemp = y;
                int indexCanMoveR = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (!hasValueNotEmpty)
                {
                    if (ChessBoard.PositionChess[indexCanMoveR] == EMPTY)
                    {
                        rs.Add(indexCanMoveR);
                    }
                    else
                    {
                        hasValueNotEmpty = true;
                    }
                }
                else
                {
                    if (ChessBoard.PositionChess[indexCanMoveR] * value < 0)
                    {
                        rs.Add(indexCanMoveR);
                        break;
                    }
                    else if (ChessBoard.PositionChess[indexCanMoveR] != EMPTY)
                    {
                        break;
                    }
                }

                countR++;
            }

            hasValueNotEmpty = false;

            int countU = 1;
            while (true)
            {
                int xTemp = x;
                int yTemp = y + countU;
                int indexCanMoveU = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (!hasValueNotEmpty)
                {
                    if (ChessBoard.PositionChess[indexCanMoveU] == EMPTY)
                    {
                        rs.Add(indexCanMoveU);
                    }
                    else
                    {
                        hasValueNotEmpty = true;
                    }
                }
                else
                {
                    if (ChessBoard.PositionChess[indexCanMoveU] * value < 0)
                    {
                        rs.Add(indexCanMoveU);
                        break;
                    }
                    else if (ChessBoard.PositionChess[indexCanMoveU] != EMPTY)
                    {
                        break;
                    }
                }
                countU++;
            }

            hasValueNotEmpty = false;

            int countD = 1;
            while (true)
            {
                int xTemp = x;
                int yTemp = y - countD;
                int indexCanMoveD = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (!hasValueNotEmpty)
                {
                    if (ChessBoard.PositionChess[indexCanMoveD] == EMPTY)
                    {
                        rs.Add(indexCanMoveD);
                    }
                    else
                    {
                        hasValueNotEmpty = true;
                    }
                }
                else
                {
                    if (ChessBoard.PositionChess[indexCanMoveD] * value < 0)
                    {
                        rs.Add(indexCanMoveD);
                        break;
                    }
                    else if (ChessBoard.PositionChess[indexCanMoveD] != EMPTY)
                    {
                        break;
                    }
                }
                countD++;
            }

            return rs;
        }

        private ArrayList GetPositionCanMoveXe()
        {
            ArrayList rs = new ArrayList();

            int countL = 1;
            while (true)
            {
                int xTemp = x - countL;
                int yTemp = y;
                int indexCanMoveL = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;

                if (IsEmptyOrHasEnemyChess(indexCanMoveL))
                {
                    rs.Add(indexCanMoveL);
                }
                if (ChessBoard.PositionChess[indexCanMoveL] != EMPTY) break;

                countL++;
            }

            int countR = 1;
            while (true)
            {
                int xTemp = x + countR;
                int yTemp = y;
                int indexCanMoveR = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (IsEmptyOrHasEnemyChess(indexCanMoveR))
                {
                    rs.Add(indexCanMoveR);
                }
                if (ChessBoard.PositionChess[indexCanMoveR] != EMPTY) break;
                countR++;
            }

            int countU = 1;
            while (true)
            {
                int xTemp = x;
                int yTemp = y + countU;
                int indexCanMoveU = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (IsEmptyOrHasEnemyChess(indexCanMoveU))
                {
                    rs.Add(indexCanMoveU);
                }
                if (ChessBoard.PositionChess[indexCanMoveU] != EMPTY) break;
                countU++;
            }

            int countD = 1;
            while (true)
            {
                int xTemp = x;
                int yTemp = y - countD;
                int indexCanMoveD = xTemp * 10 + yTemp;
                if (!IsValidPosition(xTemp, yTemp)) break;
                if (IsEmptyOrHasEnemyChess(indexCanMoveD))
                {
                    rs.Add(indexCanMoveD);
                }
                if (ChessBoard.PositionChess[indexCanMoveD] != EMPTY) break;
                countD++;
            }

            return rs;
        }

        private ArrayList GetPositionCanMoveTot()
        {
            ArrayList rs = new ArrayList();

            if ((value > 0 && y < RIVER_2) || (value < 0 && y > RIVER_1))
            {
                // not over river
                int xTemp = x;
                int yTemp = y + ValueTeam();
                int indexCanMove = x * 10 + y + 1 * ValueTeam();
                if (IsValidPosition(xTemp, yTemp) && IsEmptyOrHasEnemyChess(indexCanMove))
                {
                    rs.Add(indexCanMove);
                }
            }
            else
            {
                // over river
                int indexCanMove = x * 10 + y + 1 * ValueTeam();
                if (IsValidPosition(x, y + ValueTeam()) && IsEmptyOrHasEnemyChess(indexCanMove))
                {
                    rs.Add(indexCanMove);
                }
                int indexCanMove1 = x * 10 + y - 10;
                if (IsValidPosition(x - 1, y) && IsEmptyOrHasEnemyChess(indexCanMove1))
                {
                    rs.Add(indexCanMove1);
                }
                int indexCanMove2 = x * 10 + y + 10;
                if (IsValidPosition(x + 1, y) && IsEmptyOrHasEnemyChess(indexCanMove2))
                {
                    rs.Add(indexCanMove2);
                }

            }


            return rs;
        }

        private bool IsEmptyOrHasEnemyChessOfVua(int xVar, int yVar)
        {
            if (!IsValidPosition(xVar, yVar)) return false;
            if (xVar < MIN_CAPITAL || xVar > MAX_CAPITAL) return false;
            if (ValueTeam() > 0)
            {
                if (yVar > LINE_CAPITAL_1) return false;
            }
            else
            {
                if (yVar < LINE_CAPITAL_2) return false;
            }
            return ChessBoard.PositionChess[xVar * 10 + yVar] * value <= 0;
        }

        private bool IsEmptyOrHasEnemyChessOfSi(int xVar, int yVar)
        {
            if (!IsValidPosition(xVar, yVar)) return false;
            if (!ChessBoard.CO_UP)
            {
                if (xVar < MIN_CAPITAL || xVar > MAX_CAPITAL) return false;
                if (ValueTeam() > 0)
                {
                    if (yVar > LINE_CAPITAL_1) return false;
                }
                else
                {
                    if (yVar < LINE_CAPITAL_2) return false;
                }
            }
            return ChessBoard.PositionChess[xVar * 10 + yVar] * value <= 0;
        }

        private bool IsEmptyOrHasEnemyChessOfTuong(int xVar, int yVar)
        {
            if (!IsValidPosition(xVar, yVar)) return false;
            if (!ChessBoard.CO_UP)
            {
                if (ValueTeam() > 0)
                {
                    if (yVar > RIVER_1) return false;
                }
                else
                {
                    if (yVar < RIVER_2) return false;
                }
            }
            return ChessBoard.PositionChess[xVar * 10 + yVar] * value <= 0;
        }

        private bool IsEmptyOrHasEnemyChess(int xVar, int yVar)
        {
            return IsValidPosition(xVar, yVar)
                && ChessBoard.PositionChess[xVar * 10 + yVar] * value <= 0;
        }

        private bool IsEmptyOrHasEnemyChess(int indexCanMove)
        {
            return indexCanMove > -1 && indexCanMove < 90
                && ChessBoard.PositionChess[indexCanMove] * value <= 0;
        }

        private bool IsValidPosition(int xVar, int yVar)
        {
            return xVar > -1 && xVar < 9 && yVar > -1 && yVar < 10;
        }

        public int ValueTeam()
        {
            if (value > 0) return 1;
            else if (value < 0) return -1;
            else return 0;
        }
    }
}
