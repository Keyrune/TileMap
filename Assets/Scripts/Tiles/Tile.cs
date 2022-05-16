using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.EventSystems;
 
 
public abstract class Tile : MonoBehaviour {

    [SerializeField] internal TileHighlightController tileHighlightController;
    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _highlight;
    [SerializeField] private bool _isWalkable;
    public BaseUnit OccupiedUnit = null;
    public string TileName; 
    public Vector2 tilePosition = Vector2.zero;

    public bool Walkable => _isWalkable && OccupiedUnit == null; 


    public virtual void Init(int x, int y) {}
 


    void OnMouseEnter() {
        tileHighlightController.ChangeHighlightState(HighlightState.Active);
        MenuManager.Instance.ShowTileInfo(this);
    }
 
    void OnMouseExit()
    {
        tileHighlightController.ChangeHighlightState(HighlightState.None);
        MenuManager.Instance.ShowTileInfo(null);
    }

    private void OnMouseDown() {
        if(EventSystem.current.IsPointerOverGameObject()) return;
        UnitManager.Instance.OnTileSelected(this);

    }

    public void SetUnit(BaseUnit unit) {
        if (unit.OccupiedTile != null) unit.OccupiedTile.OccupiedUnit = null;

        unit.OccupiedTile = this;
        unit.MovePoint.transform.position = transform.position;
        OccupiedUnit = unit;
    }

    
}

