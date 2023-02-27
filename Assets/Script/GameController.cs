using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    public static event Action<GameState> OnGameStateChanged;
    public static GameController Instance;
    public GameState State;
    public int enemyTroups;//
    public int allyTroups;//
    public AudioSource victory;
    bool winCon = false;
    bool losCon = false;
    void Start()
    {
        UpdateGameState(GameState.PickColor);
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (State)
        {
            case GameState.PickColor:
                PickTeamColor();
                break;
            case GameState.Decision:
                HandleDecision();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Lose:
                HandleLose();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChanged?.Invoke(newState);
    }
    private void PickTeamColor()
    {
        //brings up UI screen with two buttons, one for black and white
        

    }
        private void HandleDecision()
    {
        //Checks if losing or winning
        //If enemy king piece gets taken then Victory
        if (winCon == true)
        {
            UpdateGameState(GameState.Victory);
            Time.timeScale = 0;
        }
        //If player king gets taken then Lose
        if (losCon == true)
        {
            UpdateGameState(GameState.Lose);
            Time.timeScale = 0;
        }
    }

    private void HandlePlayerTurn()
    {
        //Lets the player pick and move a piece
    }

    private void HandleEnemyTurn()
    {

        //Lets the Enemy pick and move a piece
    }
    private void HandleVictory()
    {
        Debug.Log("Victory");
        victory.Play();
        //Brings up the victory screen
        //Moves to the next scene
    }
    private void HandleLose()
    {
        Debug.Log("Lose");
        //Brings up the defeat screen
        //Moves to the main menu
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public enum GameState
    {
        PickColor,
        Decision,
        PlayerTurn,
        EnemyTurn,
        Victory,
        Lose
    }
}
