using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAct : MonoBehaviour
{
    [SerializeField] private GameObject block;
    private BrickState brickState;

    private void Start()
    {
        brickState = BrickState.New;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag( GameTag.Player.ToString()) && brickState==BrickState.New )
        {
            block.SetActive(false);
            brickState = BrickState.Collected;
            Player.Ins.AddBrick();

        }

    }
}
