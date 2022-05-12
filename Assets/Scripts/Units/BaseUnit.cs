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


    private void Awake() {
        MovePoint.parent = null;
    }

    public void SetSprite(Sprite newSprite) {
        _spriteRenderer.sprite = newSprite;
    }

    public void Update() {
        transform.position = Vector3.MoveTowards(transform.position, MovePoint.position, moveSpeed * Time.deltaTime);
    }

    public void Move(Tile tile) {
        tile.SetUnit(this);
    }

    public void TakeDamage(int damage) {
        health -= damage;
        Debug.Log(health);
        
    }


    
}
