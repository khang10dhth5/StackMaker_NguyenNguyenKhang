using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameState gameState;
    private void Start()
    {
        gameState = GameState.StartGame;
    }
}
