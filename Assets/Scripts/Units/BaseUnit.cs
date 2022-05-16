using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public Tile OccupiedTile;
    public Faction Faction;
    private float moveSpeed = 4f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] public Transform MovePoint;
    public string UnitName;
    public Skill ActiveSkill;
    public int health = 100;
    public int moveRange = 2;


    private void Awake() {
        MovePoint.parent = null;
    }

    public void SetSprite(Sprite newSprite) {
        _spriteRenderer.sprite = newSprite;
    }

    public void Update() {
        // Follow MovePoint
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, moveSpeed * Time.deltaTime);
    }

    public void Move(Tile tile) 
    {
        GetMoveRangeTiles();
        if (Mathf.Abs(tile.tilePosition.x - OccupiedTile.tilePosition.x) + 
            Mathf.Abs(tile.tilePosition.y - OccupiedTile.tilePosition.y) > moveRange) return;
        tile.SetUnit(this);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log(health);
        
    }

    public Dictionary<Vector2, Tile> GetMoveRangeTiles() {
        // Get tiles by move speed
        Dictionary<Vector2, Tile> moveTiles = new Dictionary<Vector2, Tile>();

        for (int x = -moveRange+1; x < moveRange; x++)
        {
            for (int y = -moveRange+1; y < moveRange; y++)
            {
                Vector2 tilePosition = new Vector2(x, y) + OccupiedTile.tilePosition;
                var tile = GridManager.Instance.GetTileAtPosition(tilePosition);
                if (tile) moveTiles[tilePosition] = tile;
                    
            }
        }

        return moveTiles;
        // Remove un walkable tiles
        // Get pathfinding value for tile
    }


    


    
}
