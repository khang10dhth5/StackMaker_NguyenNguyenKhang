using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDeAct : MonoBehaviour
{
    [SerializeField] private GameObject block;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == GameTag.Player.ToString() && GameManager.Ins.gameState == GameState.PlayGame)
        {
            block.SetActive(true);
            Player.Ins.RemoveBlock();
        }

    }
}
