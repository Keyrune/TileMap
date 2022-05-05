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
            case GameState.Deploy:
                UnitManager.Instance.SpawnUnits(Faction.Round, 2);
                UnitManager.Instance.SpawnUnits(Faction.Square, 2);
                ChangeState(GameState.RoundsTurn);
                break;
            case GameState.RoundsTurn:
                break;
            case GameState.SquaresTurn:
                break;
            case GameState.TurnLogic:
                break;    
        }   
    }


    
}

public enum GameState 
    {
        GenerateGrid,
        Deploy,
        SpawnRounds,
        SpawnSquares,
        RoundsTurn,
        SquaresTurn, 
        TurnLogic
    }
