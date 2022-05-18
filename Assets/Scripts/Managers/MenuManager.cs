using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedUnitObject, _tileObject, _tileUnitObject;
    [SerializeField] private GameObject _endTurnButton, _turnInfoObject;
    [SerializeField] private GameObject _SelectedUnitPicture;

    void Awake() {
        Instance = this;
    }

    public void ShowTileInfo(Tile tile) {

        if (tile == null)
        {
            _tileObject.SetActive(false);
            _tileUnitObject.SetActive(false);
            return;
        }

        _tileObject.GetComponentInChildren<Text>().text = tile.TileName;
        _tileObject.SetActive(true);

        if (tile.OccupiedUnit) {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.UnitName;
            _tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedUnit(BaseUnit unit) {
        if (unit == null) {
            _selectedUnitObject.SetActive(false);
            return;
        }

        _SelectedUnitPicture.GetComponent<Image>().sprite = unit.GetComponent<SpriteRenderer>().sprite;
        _SelectedUnitPicture.GetComponent<Image>().SetNativeSize();
        _selectedUnitObject.GetComponentInChildren<Text>().text = unit.UnitName;
        _selectedUnitObject.SetActive(true);
    }

    public void ShowTurnInfo(Faction faction) {
        switch (faction)
        {
            case Faction.Round:
                _turnInfoObject.GetComponentInChildren<Text>().text = "Rounds";
                break;
            case Faction.Square:
                _turnInfoObject.GetComponentInChildren<Text>().text = "Squares";
                break;
            default:
                _turnInfoObject.GetComponentInChildren<Text>().text = "none";
                break;
        }
    }
}