using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Skill", menuName="Hit Skill")]
public class Hit_skill : Skill
{
    public int damage;

    public override void Activate(params Tile[] targets)
    {
        foreach (var tile in targets)
        {
            BaseUnit unit = tile.OccupiedUnit;
            if (unit == null) return;
            unit.TakeDamage(damage);
        }
    }
}
