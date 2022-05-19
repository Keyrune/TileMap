using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_skill : Skill
{


    public override void Activate(params Tile[] targets)
    {   
        if (targets.Length < 2) return;
        
    }
}
