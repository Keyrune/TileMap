using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public abstract class Tile : MonoBehaviour {

    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;
    public BaseUnit OccupiedUnit = null;
    
    public bool Walkable => _isWalkable && OccupiedUnit == null; 


    public virtual void Init(int x, int y) {
        
    }
 
    void OnMouseEnter() {
        _highlight.SetActive(true);
        MenuManager.Instance.ShowTileInfo(this);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
        MenuManager.Instance.ShowTileInfo(null);
    }

    private void OnMouseDown() {
        if(GameManager.Instance.GameState != GameState.RoundsTurn) return;
        if (!_isWalkable) return;

        if (OccupiedUnit != null) {
            if(OccupiedUnit.Faction == Faction.Round) UnitManager.Instance.SetSelectedUnit((BaseUnit)OccupiedUnit);
            else {
                if (UnitManager.Instance.SelectedUnit != null) {
                    var enemy = (BaseUnit) OccupiedUnit;
                    Destroy(enemy.gameObject);
                    UnitManager.Instance.SetSelectedUnit(null);
                }
            }
        }
        else {
            if (UnitManager.Instance.SelectedUnit != null) {
                SetUnit(UnitManager.Instance.SelectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
        }

    }

    public void SetUnit(BaseUnit unit) {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;

        unit.OccupiedTile = this;
        OccupiedUnit = unit;
        unit.Move(transform.position);

    }
}