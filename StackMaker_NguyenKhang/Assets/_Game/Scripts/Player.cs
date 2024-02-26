using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :Singleton<Player>
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform model;
    [SerializeField] private GameObject block;

    private Vector3 startPosition, endPosition;
    private Vector3 lastPositon;
    private Vector3 currentBlockPos;
    private Stack listBlock=new Stack();
    private void Start()
    {
        OnInit();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
        }

        if (Input.GetMouseButtonUp(0))
        {
            endPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1.0f));
            CheckSwipe();
        }

        if (Vector3.Distance(transform.position,lastPositon)>0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, lastPositon, moveSpeed * Time.deltaTime);
        }
    }

    public void AddBlock()
    {
        GameObject b = Instantiate(block, new Vector3(model.position.x, currentBlockPos.y, model.position.z), Quaternion.identity);
        b.transform.SetParent(model);
        model.position = model.position + new Vector3(0,0.31f, 0);
        listBlock.Push(b);
    }
    public void RemoveBlock()
    {
        if(listBlock.Count>0)
        {
            GameObject block= listBlock.Pop() as GameObject;
            Destroy(block);
            model.position = model.position - new Vector3(0, 0.3f, 0);
        }
        
    }

    private void OnInit()
    {
        lastPositon = transform.position;
        currentBlockPos.y = model.position.y-0.4f;
    }


    private void CheckSwipe()
    {
        if(VerticalMove()>HorizontalMove() )
        {
            if(startPosition.y-endPosition.y<0)
            {
                Debug.Log("Up");
                OnSwipeUp();
            }
            else if (startPosition.y - endPosition.y > 0)
            {
                Debug.Log("Down");
                OnSwipeDown();
            }
           
        }
        else if(HorizontalMove()>VerticalMove() )
        {

            if (startPosition.x - endPosition.x < 0)
            {
                Debug.Log("Right");
                OnSwipeRight();
            }
            else if (startPosition.x- endPosition.x > 0)
            {
                Debug.Log("Left");
                OnSwipeLeft();
            }
        }
        startPosition = endPosition;
        
        
    }
    private void CheckEndPoint(Vector3 dirRayCast)
    {
       lastPositon = transform.position;
       while(true)
        {
            Physics.Raycast(lastPositon + dirRayCast+Vector3.up, Vector3.down, out RaycastHit hit, 10f);
            Debug.DrawRay(lastPositon + dirRayCast, Vector3.down, Color.blue, 5f);
            if (hit.transform==null||hit.transform.tag != GameTag.Brick.ToString())
            {
                return;
            }
            lastPositon = lastPositon + dirRayCast;
            if(GameManager.Ins.gameState==GameState.StartGame)
            {
                AddBlock();
                GameManager.Ins.gameState = GameState.PlayGame;
            }
        }


    }
    private void OnSwipeDown()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, RotationConstant.ROTATION_DOWN, 0));
        CheckEndPoint(RaycastConstant.DOWN_RAYCAST);
    }

    private void OnSwipeLeft()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, RotationConstant.ROTATION_LEFT, 0));
        CheckEndPoint(RaycastConstant.LEFT_RAYCAST);
    }

    private void OnSwipeRight()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, RotationConstant.ROTATION_RIGHT, 0));
        CheckEndPoint(RaycastConstant.RIGHT_RAYCAST);
    }

    private void OnSwipeUp()
    {
        transform.rotation= Quaternion.Euler(new Vector3(0, RotationConstant.ROTATION_UP, 0));
        CheckEndPoint(RaycastConstant.UP_RAYCAST);
    }

    private float VerticalMove()
    {
        return Mathf.Abs(startPosition.y - endPosition.y);
    }

    private float HorizontalMove()
    {
        return Mathf.Abs(startPosition.x - endPosition.x);
    }

}
