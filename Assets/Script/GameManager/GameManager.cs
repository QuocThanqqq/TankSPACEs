using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState State { get; set; }
    
    
    
    void Start() => ChangeState(GameState.Loading);
    
    // Change State
    public void ChangeState(GameState gameState)
    {
        State = gameState;
        switch (gameState)
        {
            case GameState.Loading:
                HandleLoading();
                break;
            case GameState.CountToPlay:
                HandleCountToPlay();
                break;
            case GameState.Playing:
                HandlePlaying();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }
    
        Debug.Log($"New state: {gameState}");
    }
    
    private async void HandleLoading()
    {
        GameUIManager.Instance.ViewLoadings.Show();
        await UniTask.Delay(5000);
        ChangeState(GameState.CountToPlay);
    }
    
    private async void HandleCountToPlay()
    {
        Debug.Log("Get to count to play");
        GameUIManager.Instance.ViewLoadings.Hide();
        GameUIManager.Instance.ViewInGame.Show();
        await UniTask.Delay(4000);
        ChangeState(GameState.Playing);
    }
    
    private void HandlePlaying()
    {
        //GameUIManager.Instance.ViewGameFinish.Show();
        
    }
    
    
}
public enum GameResult
{
    Win,
    Lose
}
public enum GameState
{
   Loading,
   CountToPlay,
   Playing
   
}