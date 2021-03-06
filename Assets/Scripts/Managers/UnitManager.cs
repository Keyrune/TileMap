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
    private Skill _selectedSkill = null;
    [SerializeField] BaseUnit unitPrefab;


    private void Awake() {
        Instance = this;

        _units = Resources.LoadAll<ScriptableUnit>("Animals").ToList();
    }

    
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

    public void SetSelectedSkill(Skill skill) 
    {
        _selectedSkill = skill;

        if (_selectedSkill != null) 
        {   
            GridManager.Instance.ClearAllHighlight();
            GridManager.Instance.ShowSkillRange(skill.GetSkillRangeTiles());
        }
    }

    public void SetSelectedUnit(BaseUnit unit) 
    {
        // Update move range 
        GridManager.Instance.ClearAllHighlight();
        if (unit != null) 
        {   
            GridManager.Instance.ShowMoveRange(unit.GetMoveRangeTiles());
        }

        SelectedUnit = unit;
        MenuManager.Instance.ShowSelectedUnit(unit);

    }

    public void OnTileSelected(Tile tile) {
        if(!CombatManager.Instance.ActiveTurn) return;

        if (_selectedSkill) 
        {
            // give target to selected skill
            // out of range diselect unit
        }

        // if no unit select unit
        // if unit move/diselect unit


        if (tile.OccupiedUnit != null) 
        {
            if(tile.OccupiedUnit.Faction == CombatManager.Instance.ActiveFaction) 
                SetSelectedUnit((BaseUnit)tile.OccupiedUnit);
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
