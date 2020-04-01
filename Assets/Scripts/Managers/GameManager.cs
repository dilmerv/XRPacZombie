using DilmerGames.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

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

    [SerializeField]
    private VolumeProfile volumeProfile = null;

    [SerializeField]
    private string[] componentsToFind;

    private float gameTimer = 0;

    private void Awake()
    {
        ApplyZombiePostProcessingEffects(false);
    }

    private void Update()
    {
        if (gameMode == GameMode.GameOver || gameMode == GameMode.Menu)
        {
            return;
        }

        gameTimer += Time.deltaTime * 1.0f;

        // if the gameTimer >= 30 and gameTimer <= 40
        // zombie mode checks
        if (gameTimer >= normalGameModeTime && gameTimer <= (normalGameModeTime + zombieModeTime))
        {
            gameMode = GameMode.Zombie;
            ApplyZombiePostProcessingEffects(true);
        }

        // if the gameTimer >= 30 and gameTimer <= 40
        // from zombie mode to normal mode after we reached > 40
        if (gameTimer > (normalGameModeTime + zombieModeTime))
        {
            gameMode = GameMode.Normal;
            gameTimer = 0;
            ApplyZombiePostProcessingEffects(false);
        }
    }
    private void ApplyZombiePostProcessingEffects(bool state)
    {
        if (componentsToFind?.Count() > 0)
        {
            var components = volumeProfile.components.Where(c => c);
            foreach (var c in components)
            {
                if (componentsToFind.Contains(c.name))
                {
                    c.active = state;
                }
            }
        }
    }


}
