using System.Collections;
using UnityEngine;
using ChineseChess;
using System;

public class ChessController : MonoBehaviour
{
    public int index;
    public int value;
    private Chess chess;

    public Sprite[] sprites;

    private float speed = 10f;
    private Vector3 target;
    private bool isMoving = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check onclick
        if (!isMoving)
        {
            RaycastHit hit = new RaycastHit();
            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.GetTouch(i).phase.Equals(TouchPhase.Began))
                {
                    // Construct a ray from the current touch coordinates
                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                    if (Physics.Raycast(ray, out hit))
                        hit.transform.gameObject.SendMessage("OnMouseDown");
                }
            }
        }

        //move chess to position
        if (isMoving)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);

            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Ok");

        int turn = GameBoardController.IsRedTurn ? 1 : -1;
        if (turn * value <= 0) return;
        ShowPositionCanMove();
    }

    private void ShowPositionCanMove()
    {
        if (chess == null) return;
        ArrayList positionCanMoves = chess.GetPositionCanMove();
        if (positionCanMoves.Count == 0)
        {
            Debug.Log("Can not move");
        }
        else
        {
            if (moveListener != null)
            {
                moveListener.OnShow(this, positionCanMoves);
            }
        }
    }

    public void SetValue(int mValue, int xVar, int yVar)
    {
        index = xVar * 10 + yVar;
        value = mValue;
        if (value == 0) return;
        if (value > 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[value - 1];
        }
        if (value < 0)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[7 + (-value) - 1];
        }
        chess = new Chess
        {
            x = xVar,
            y = yVar,
            value = mValue
        };
    }

    private OnShowPosCanMoveListener moveListener;

    public void SetOnShowPosCanMoveListener(OnShowPosCanMoveListener listener)
    {
        moveListener = listener;
    }

    public interface OnShowPosCanMoveListener
    {
        void OnShow(ChessController chess, ArrayList posCanMove);
    }

    internal void MoveToPosition(float xWorld, float yWorld)
    {
        target = new Vector3(xWorld, yWorld, transform.position.z);
        isMoving = true;
    }

    internal void UpdateXY(int i)
    {
        index = i;
        int x = i / 10;
        int y = i % 10;
        chess.x = x;
        chess.y = y;
    }

    internal void Lose()
    {
        transform.gameObject.SetActive(false);
    }

    public Chess GetChess()
    {
        return chess;
    }
}
