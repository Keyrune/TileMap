using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public void Activate(params BaseUnit[] targets) {
        foreach (var target in targets) {
            target.TakeDamage(15);
        }
    }
}
