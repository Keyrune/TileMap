using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;
    public Faction ActiveFaction; 
    public bool ActiveTurn = false;


    private void Awake() 
    {
        Instance = this;
    }


    public void StartTurn(Faction faction) 
    // Start turn for selected faction
    {   
        ActiveTurn = true;
        ActiveFaction = faction;

        MenuManager.Instance.ShowTurnInfo(faction);
        

    }

    public void EndTurn() 
    {
        ActiveTurn = false;
        UnitManager.Instance.SetSelectedUnit(null);

        switch (ActiveFaction)
        {
            case Faction.Round:
                GameManager.Instance.ChangeState(GameState.SquaresTurn);
                break;
            case Faction.Square:
                GameManager.Instance.ChangeState(GameState.RoundsTurn);
                break;
            default:
                break;
        }
    }

    
    


}
