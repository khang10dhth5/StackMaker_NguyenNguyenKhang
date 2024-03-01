using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player :Singleton<Player>
{
    public Stack listBrick = new Stack();
    public Vector3 lastPositon;

    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform model;
    [SerializeField] private GameObject brickPrefab;
    [SerializeField] private Animator amin;
    private Vector3 startPosition, endPosition;
    private Vector3 currentBlockPos;
    private bool isMove;
    private float SWIPE_THRESHOLD = 0.3f;

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

        if (Vector3.Distance(transform.position,lastPositon)>0.1f && GameManager.Ins.gameState==GameState.PlayGame)
        {
            isMove = true;
            transform.position = Vector3.MoveTowards(transform.position, lastPositon, moveSpeed * Time.deltaTime);
        }
        if(Vector3.Distance(transform.position, lastPositon) < 0.1f)
        {
            isMove = false;
            amin.SetInteger(AminConstant.KEY_ADDBRICK, 0);
        }
    }
    public void EndGame()
    {
        amin.SetInteger(AminConstant.KEY_WIN, 2);
    }
    public void ClearBrick()
    {
        DesTroyListBrick();
        model.position = new Vector3(model.position.x,currentBlockPos.y+0.5f,model.position.z);
    }
    public void DesTroyListBrick()
    {
        foreach(GameObject brick in listBrick)
        {
            Destroy(brick);
        }
        listBrick.Clear();
    }
    public void AddBrick()
    {
        GameObject brick = Instantiate(brickPrefab, new Vector3(model.position.x, currentBlockPos.y, model.position.z), Quaternion.identity);
        brick.transform.SetParent(model);
        model.position = model.position + new Vector3(0,0.4f, 0);
        listBrick.Push(brick);
        
    }
    public void RemoveBrick()
    {
        if(listBrick.Count>0)
        {
            GameObject brick= listBrick.Pop() as GameObject;
            Destroy(brick);
            model.position = model.position - new Vector3(0, 0.4f, 0);
        }
        
    }

    private void OnInit()
    {
        lastPositon = transform.position;
        currentBlockPos.y = model.position.y-1f;
        isMove = false;
    }


    private void CheckSwipe()
    {
        if (!isMove)
        {
            if (VerticalMove() > SWIPE_THRESHOLD && VerticalMove() > HorizontalMove())
            {
                if (startPosition.y - endPosition.y < 0)
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
            else if (HorizontalMove() > SWIPE_THRESHOLD && HorizontalMove() > VerticalMove())
            {

                if (startPosition.x - endPosition.x < 0)
                {
                    Debug.Log("Right");
                    OnSwipeRight();
                }
                else if (startPosition.x - endPosition.x > 0)
                {
                    Debug.Log("Left");
                    OnSwipeLeft();
                }
            }
            startPosition = endPosition;
            amin.SetInteger(AminConstant.KEY_ADDBRICK, 1);
        }
        
    }
    private void CheckEndPoint(Vector3 dirRayCast)
    {
       lastPositon = transform.position;
       while(true)
        {
            Physics.Raycast(lastPositon + dirRayCast+Vector3.up, Vector3.down, out RaycastHit hit, 10f);
            //Debug.DrawRay(lastPositon + dirRayCast, Vector3.down, Color.blue, 5f);
            if (hit.transform==null||hit.transform.tag != GameTag.Brick.ToString())
            {   
                if(hit.transform==null)
                {
                    Debug.Log("null");
                }
                if(hit.transform!=null)
                {
                    Debug.LogError(hit.transform.tag);
                }
                return;
            }
            lastPositon = lastPositon + dirRayCast;
            if(GameManager.Ins.gameState==GameState.StartGame)
            {
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
