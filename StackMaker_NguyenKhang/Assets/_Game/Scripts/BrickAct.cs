using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickAct : MonoBehaviour
{
    [SerializeField] private GameObject block;
    [SerializeField] private Collider collider;
    private BrickState brickState;

    private void Start()
    {
        brickState = BrickState.New;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (GameManager.Ins.gameState == GameState.PlayGame && collision.transform.tag == GameTag.Player.ToString() && brickState==BrickState.New )
        {
            block.SetActive(false);
            brickState = BrickState.Collected;
            Player.Ins.AddBlock();

        }

    }
}
