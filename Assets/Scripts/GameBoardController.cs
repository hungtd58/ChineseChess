using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChineseChess;
using System;

public class GameBoardController : MonoBehaviour, ChessController.OnShowPosCanMoveListener, DotController.OnMoveClickListener
{
    public Transform chess, dot;

    public static readonly ArrayList XYValues = new ArrayList();

    public ArrayList mCanMovePositions = new ArrayList();

    ArrayList mDots = new ArrayList();

    private ChessController mCurrentChess = null;
    ArrayList AllChessList = new ArrayList();

    public static bool IsRedTurn = true;
    Chess KingRed, KingBlue;

    // Use this for initialization
    void Start()
    {
        float xSize = GetComponent<Renderer>().bounds.size.x; ;
        Camera.main.orthographicSize = xSize * Screen.height / Screen.width * 0.5f;

        InitChessBoard();

        int[,] mInitValue = ChessBoard.GameBoardOrigin;

        float unit = xSize / 9f;
        float xStart = -4f * unit;
        float yStart = -4.5f * unit;

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                XY newPoint = new XY
                {
                    mX = i,
                    mY = j,
                    mXWorld = xStart + unit * i,
                    mYWorld = yStart + unit * j
                };
                XYValues.Add(newPoint);
            }
        }

        for (int i = 0; i < mInitValue.GetLength(0); i++)
        {
            for (int j = 0; j < mInitValue.GetLength(1); j++)
            {
                int index = i * 10 + j;
                XY point = (XY)XYValues[index];
                if (mInitValue[i, j] != Chess.EMPTY)
                {
                    Transform newChess = Instantiate(chess, new Vector3(point.mXWorld, point.mYWorld, -1), Quaternion.identity);
                    ChessController controller = newChess.GetComponent<ChessController>();
                    controller.SetValue(mInitValue[i, j], i, j);
                    controller.SetOnShowPosCanMoveListener(this);

                    if (mInitValue[i,j] == Chess.VUA_1) {
                        KingRed = controller.GetChess();
                    }
                    if (mInitValue[i, j] == Chess.VUA_2)
                    {
                        KingBlue = controller.GetChess();
                    }

                    AllChessList.Add(controller);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnShow(ChessController chess, ArrayList posCanMove)
    {
        ClearDotOnBoard();

        foreach (int pos in posCanMove)
        {
            XY point = (XY)XYValues[pos];
            Transform newDot = Instantiate(dot, new Vector3(point.mXWorld, point.mYWorld, -1), Quaternion.identity);
            DotController controller = newDot.GetComponent<DotController>();
            controller.SetIndex(pos);
            controller.SetOnMoveClickListener(this);
            mDots.Add(newDot);
        }

        mCurrentChess = chess;
    }

    public void OnMove(DotController controller, float xWorld, float yWorld)
    {
        if (mCurrentChess == null) return;
        mCurrentChess.MoveToPosition(xWorld, yWorld);

        UpdateValueOnBoard(controller.GetIndex());
        ClearDotOnBoard();
    }

    void CheckCheckMate()
    {
        int turn = IsRedTurn ? 1 : -1;

        foreach (ChessController chessController in AllChessList)
        {
            bool find = false;
            Chess c = chessController.GetChess();

            if (turn * c.value < 0) continue;

            ArrayList moves = c.GetPositionCanMove();
            foreach (int move in moves)
            {
                Debug.Log("Index: " + move);
                if (!IsRedTurn)
                {
                    if (KingRed.x == move / 10 && KingRed.y == move % 10)
                    {
                        Debug.Log("Check Red");
                        find = true;
                        break;
                    }
                }
                else
                {
                    if (KingBlue.x == move / 10 && KingBlue.y == move % 10)
                    {
                        Debug.Log("Check Blue");
                        find = true;
                        break;
                    }
                }
            }

            if (find)
                return;
        }
    }

    private void UpdateValueOnBoard(int index)
    {
        ChessBoard.PositionChess[mCurrentChess.index] = Chess.EMPTY;
        ChessBoard.PositionChess[index] = mCurrentChess.value;

        mCurrentChess.UpdateXY(index);

        foreach (ChessController mChess in AllChessList)
        {
            if (mChess.index == index && mChess.value != mCurrentChess.value)
            {
                mChess.Lose();
                break;
            }
        }

        CheckCheckMate();
        //finaly
        mCurrentChess = null;

        IsRedTurn = !IsRedTurn;
    }

    public void ClearDotOnBoard()
    {
        for (int i = mDots.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(((Transform)mDots[i]).gameObject);
        }
        mDots.Clear();
    }

    private void InitChessBoard()
    {
        for (int i = 0; i < 90; i++)
        {
            ChessBoard.PositionChess[i] = ChessBoard.GameBoardOrigin[i / 10, i % 10];
        }
    }
}
