using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotController : MonoBehaviour
{
    private int index;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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

    public int GetIndex()
    {
        return index;
    }

    public void SetIndex(int index)
    {
        this.index = index;
    }

    public void OnMouseDown()
    {
        Debug.Log("Move");
        MoveToThisPosition();
    }

    private void MoveToThisPosition()
    {
        if (moveClickListener != null)
        {
            moveClickListener.OnMove(this, transform.position.x, transform.position.y);
        }
    }

    private OnMoveClickListener moveClickListener;

    public void SetOnMoveClickListener(OnMoveClickListener onMoveClickListener)
    {
        moveClickListener = onMoveClickListener;
    }

    public interface OnMoveClickListener
    {
        void OnMove(DotController controller, float xWorld, float yWorld);
    }
}