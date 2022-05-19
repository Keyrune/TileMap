using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Skill", menuName="Heal Skill")]
public class Heal_skill : Skill
{
    public int healAmount;

    public override void Activate(params Tile[] targets)
    {
        foreach (var tile in targets)
        {
            BaseUnit unit = tile.OccupiedUnit;
            if (unit == null) return;
            unit.Heal(healAmount);
        }
    }
}
