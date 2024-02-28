using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDeAct : MonoBehaviour
{
    [SerializeField] private GameObject block;
    private BrickState brickState;

    private void Start()
    {
        brickState = BrickState.DeAct;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == GameTag.Player.ToString()  && brickState==BrickState.DeAct)
        {
            if(Player.Ins.listBrick.Count>0)
            {
                block.SetActive(true);
                Player.Ins.RemoveBrick();
                brickState = BrickState.Act;
            }
        }

    }
}
