using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Unit", menuName="Scriptable Unit")]
public class ScriptableUnit : ScriptableObject
{
    public Faction Faction;
    public Sprite roundSprite;
    public Sprite squareSprite;
    


    public Sprite GetSprite(Faction faction) {
        switch (faction)
        {
            case Faction.Round:
                return roundSprite;
            case Faction.Square:
                return squareSprite;
        }
        return null;
    }

    
    
}

public enum Faction {
        Round,
        Square
}
