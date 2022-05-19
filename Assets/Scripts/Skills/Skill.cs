using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Scriptable Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite skillIcon;
    public AreaShape areaShape;
    public int range;
    public int numberOfTargets;


    public virtual void Activate(params Tile[] targets) {}

    public Dictionary<Vector2, Tile> GetSkillRangeTiles()
    {
        Dictionary<Vector2, Tile> skillRangeTiles = new Dictionary<Vector2, Tile>();

        Vector2 unitPosition = UnitManager.Instance.SelectedUnit.OccupiedTile.tilePosition;

        switch (areaShape)
        {
            case AreaShape.Plus:
                skillRangeTiles = GetPlusArea(unitPosition);
                break;
        }

        skillRangeTiles = GetPlusArea(unitPosition);
        return skillRangeTiles;
    }

    public Dictionary<Vector2, Tile> GetPlusArea(Vector2 unitPosition) 
    {   
        Dictionary<Vector2, Tile> tiles = new Dictionary<Vector2, Tile>();

        Vector2 tilePosition;
        Tile tile;

        for (int x = 1; x <= range; x++)
        {   
            tilePosition = new Vector2(unitPosition.x + x, unitPosition.y);
            tile = GridManager.Instance.GetTileAtPosition(tilePosition);
            
            if (tile != null) tiles[tilePosition] = tile;

            tilePosition = new Vector2(unitPosition.x - x, unitPosition.y);
            tile = GridManager.Instance.GetTileAtPosition(tilePosition);

            if (tile != null) tiles[tilePosition] = tile;
        }

        for (int y = 1; y <= range; y++)
        {
            tilePosition = new Vector2(unitPosition.x, unitPosition.y + y);
            tile = GridManager.Instance.GetTileAtPosition(tilePosition);
            
            if (tile != null) tiles[tilePosition] = tile;

            tilePosition = new Vector2(unitPosition.x, unitPosition.y - y);
            tile = GridManager.Instance.GetTileAtPosition(tilePosition);

            if (tile != null) tiles[tilePosition] = tile;
        }

        return tiles;
    }

    // private List<Vector2> GetStarArea() 
    // {   
    //     List<Vector2> tiles = new List<Vector2>();

    //     return tiles;
    // }

    // private List<Vector2> GetBoxArea() 
    // {   
    //     List<Vector2> tiles = new List<Vector2>();

    //     return tiles;
    // }


}

public enum AreaShape 
{
    Plus,
    Star,
    Box
}
