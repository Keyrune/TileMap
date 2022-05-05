using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : MonoBehaviour
{
    public Tile OccupiedTile;
    public Faction Faction;
    private float moveSpeed = 4f;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] public Transform _movePoint;

    private void Awake() {
        _movePoint.parent = null;
    }

    public void SetSprite(Sprite newSprite) {
        _spriteRenderer.sprite = newSprite;
    }

    public void Update() {
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, moveSpeed * Time.deltaTime);
    }

    public void Move(Vector3 newPosition) {
        _movePoint.position = newPosition;
    }
}
