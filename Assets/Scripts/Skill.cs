using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Scriptable Skill")]
public class Skill : ScriptableObject
{
    public void Activate(params BaseUnit[] targets) {
        foreach (var target in targets) {
            target.TakeDamage(15);
        }
    }
}
