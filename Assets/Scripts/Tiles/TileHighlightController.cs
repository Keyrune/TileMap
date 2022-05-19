using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlightController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Tile tileScript;
    private bool _mouseHover, _moveRange, _skillRange = false;


    public void ShowMoveRange(bool newValue)
    {
        _moveRange = newValue;
        UpdateHighlight();
    }

    public void ShowSkillRange(bool newValue)
    {
        _skillRange = newValue;
        UpdateHighlight();
    }

    public void ChangeMouseHover(bool newValue)
    {
        _mouseHover = newValue;
        UpdateHighlight();
    }

    public void UpdateHighlight() {

        if (_mouseHover) 
        {
            _renderer.color = new Color(0.5f, 0.5f, 0.5f, 1f);
            return;
        }

        if (_skillRange)
        {
            _renderer.color = Color.red;
            return;
        }

        if (_moveRange)
        {
            _renderer.color = Color.green;
            return;
        }



        _renderer.color = new Color(0.5f, 0.5f, 0.5f, 0f);
    }

}
