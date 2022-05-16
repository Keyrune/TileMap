using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlightController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Tile tileScript;


    public void ChangeHighlightState(HighlightState highlightState) {

        switch (highlightState) {
            case HighlightState.None:
                _renderer.color = new Color(0.5f, 0.5f, 0.5f, 0f);
                break;
            case HighlightState.Active:
                _renderer.color = Color.white;
                break;
            case HighlightState.MoveRange:
                break;
            case HighlightState.SkillRange:
                break;
        }
    }

}


public enum HighlightState {
    None,
    Active,
    MoveRange,
    SkillRange
}