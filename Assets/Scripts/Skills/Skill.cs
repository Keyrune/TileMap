using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Scriptable Skill")]
public class Skill : ScriptableObject
{
    public string skillName;
    public Sprite skillIcon;
    public AreaShape AreaShape;
    public int range;
    public int numberOfTargets;


    public virtual void Activate(params Tile[] targets) {}

}

public enum AreaShape 
{
    Plus,
    Star,
    Box
}
