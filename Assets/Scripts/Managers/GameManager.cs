using DilmerGames.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public enum GameMode
    {
        Normal,
        Zombie,
        GameOver,
        Menu,
    }

    public GameMode gameMode = GameMode.Normal;

    [SerializeField]
    private float normalGameModeTime = 30.0f;

    [SerializeField]
    private float zombieModeTime = 10.0f;

    private float gameTimer = 0;


    private void Update()
    {
        if (gameMode == GameMode.GameOver || gameMode == GameMode.Menu)
        {
            return;
        }

        gameTimer += Time.deltaTime * 1.0f;

        Debug.Log(gameTimer);
        Debug.Log(gameMode);

        // if the gameTimer >= 30 and gameTimer <= 40
        // zombie mode checks
        if (gameTimer >= normalGameModeTime && gameTimer <= (normalGameModeTime + zombieModeTime))
        {
            gameMode = GameMode.Zombie;
        }

        // if the gameTimer >= 30 and gameTimer <= 40
        // from zombie mode to normal mode after we reached > 40
        if (gameTimer > (normalGameModeTime + zombieModeTime))
        {
            gameMode = GameMode.Normal;
            gameTimer = 0;
        }
    }

}
