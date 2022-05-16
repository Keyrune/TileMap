using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassTile : Tile {
    [SerializeField] private Color _baseColor, _offsetColor;

    public override void Init(int x, int y) {
        var isOffset = (x + y) % 2 == 1;
        tilePosition = new Vector2(x, y); 
        _renderer.color = isOffset ? _offsetColor : _baseColor;
    }

}
