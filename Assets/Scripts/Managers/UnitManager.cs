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

        _units = Resources.LoadAll<ScriptableUnit>("").ToList();
    }

    public void SpawnRoundUnits() {
        Faction faction = Faction.Round;

        var randomData = GetRandomUnit();
        var spawnedUnit = Instantiate(unitPrefab);
        spawnedUnit.Faction = faction;
        spawnedUnit.SetSprite(randomData.GetSprite(faction)); 

        var randomSpawnTile = GridManager.Instance.GetRoundSpawnTile();

        randomSpawnTile.SetUnit(spawnedUnit);

        GameManager.Instance.ChangeState(GameState.SpawnSquares);

    }

    public void SpawnSquareUnits() {
        Faction faction = Faction.Square;

        var randomData = GetRandomUnit();
        var spawnedUnit = Instantiate(unitPrefab);
        spawnedUnit.Faction = faction;
        spawnedUnit.SetSprite(randomData.GetSprite(faction)); 

        var randomSpawnTile = GridManager.Instance.GetSquareSpawnTile();

        randomSpawnTile.SetUnit(spawnedUnit);

        GameManager.Instance.ChangeState(GameState.RoundsTurn);
    }

    private ScriptableUnit GetRandomUnit() {
        return _units[0];
    }

    public void SetSelectedUnit(BaseUnit unit) {
        SelectedUnit = unit;
        //MenuManager.Instance.ShowSelectedHero(hero);
    }


}
