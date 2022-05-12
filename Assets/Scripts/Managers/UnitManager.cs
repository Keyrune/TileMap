using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEditor;


public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    private List<ScriptableUnit> _units;
    public BaseUnit SelectedUnit;
    [SerializeField] BaseUnit unitPrefab;

    private void Awake() {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Animals").ToList();
    }

    // public void SpawnRoundUnits() {
    //     Faction faction = Faction.Round;

    //     var randomData = GetRandomUnit<ScriptableUnit>(Faction.Round);
    //     var spawnedUnit = Instantiate(unitPrefab);
    //     spawnedUnit.Faction = faction;
    //     spawnedUnit.SetSprite(randomData.GetSprite(faction)); 

    //     var randomSpawnTile = GridManager.Instance.GetRoundSpawnTile();

    //     randomSpawnTile.SetUnit(spawnedUnit);

    //     GameManager.Instance.ChangeState(GameState.SpawnSquares);

    // }

    // public void SpawnSquareUnits() {
    //     Faction faction = Faction.Square;

    //     var randomData = GetRandomUnit<ScriptableUnit>(Faction.Square);
    //     var spawnedUnit = Instantiate(unitPrefab);
    //     spawnedUnit.Faction = faction;
    //     spawnedUnit.SetSprite(randomData.GetSprite(faction)); 

    //     var randomSpawnTile = GridManager.Instance.GetSquareSpawnTile();

    //     randomSpawnTile.SetUnit(spawnedUnit);

    //     GameManager.Instance.ChangeState(GameState.RoundsTurn);
    // }

    public void SpawnUnits(Faction faction, int numberOfUnits = 1) {
        for (int i = 0; i < numberOfUnits; i++)
        {
            var randomData = GetRandomUnit<ScriptableUnit>(Faction.Square);
            var spawnedUnit = Instantiate(unitPrefab);
            spawnedUnit.Faction = faction;
            spawnedUnit.SetSprite(randomData.GetSprite(faction)); 
            spawnedUnit.UnitName = randomData.UnitName;

            var randomSpawnTile = GridManager.Instance.GetSpawnTile(faction);
            spawnedUnit.transform.position = randomSpawnTile.transform.position;
            randomSpawnTile.SetUnit(spawnedUnit);
        }
    }


    private T GetRandomUnit<T>(Faction faction) where T : ScriptableUnit {
        return (T)_units.OrderBy(u => Random.value).First();
    }

    public void SetSelectedUnit(BaseUnit unit) {
        SelectedUnit = unit;
        MenuManager.Instance.ShowSelectedUnit(unit);
    }

    public void OnTileSelected(Tile tile) {
        if(!CombatManager.Instance.ActiveTurn) return;

        if (tile.OccupiedUnit != null) {
            if(tile.OccupiedUnit.Faction == CombatManager.Instance.ActiveFaction) SetSelectedUnit((BaseUnit)tile.OccupiedUnit);
            else {
                if (SelectedUnit != null) {
                    var enemy = (BaseUnit) tile.OccupiedUnit;
                    SelectedUnit.ActiveSkill.Activate(enemy);
                    SetSelectedUnit(null);
                }
            }
        }
        else {
            if (SelectedUnit != null) {
                if (!tile.Walkable) return;
                SelectedUnit.Move(tile);
                SetSelectedUnit(null);
            }
        }
    }

}
