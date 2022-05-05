using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;


    private void Awake() 
    {
        Instance = this;
    }

    private void Start() 
    {
        ChangeState(GameState.GenerateGrid);
    }

    public void ChangeState(GameState newState) 
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.GenerateGrid:
                GridManager.Instance.GenerateGrid();
                break;
            case GameState.SpawnRounds:
                UnitManager.Instance.SpawnRoundUnits();
                break;
            case GameState.SpawnSquares:
                UnitManager.Instance.SpawnSquareUnits();
                break;
            case GameState.RoundsTurn:
                break;
            case GameState.SquaresTurn:
                break;    
        }   
    }


    
}

public enum GameState 
    {
        GenerateGrid = 0,
        SpawnRounds = 1,
        SpawnSquares = 2,
        RoundsTurn = 3,
        SquaresTurn = 4
    }

// public enum GameState 
// {
//     GenerateGrid,
//     UnitSelect,         
//     Deploy, 
//     RoundsTurn,
//     SquaresTurn
// }