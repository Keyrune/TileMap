using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
    public static MenuManager Instance;

    [SerializeField] private GameObject _selectedUnitObject, _tileObject, _tileUnitObject;

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

        _tileObject.GetComponentInChildren<Text>().text = tile.name;
        _tileObject.SetActive(true);

        if (tile.OccupiedUnit) {
            _tileUnitObject.GetComponentInChildren<Text>().text = tile.OccupiedUnit.name;
            _tileUnitObject.SetActive(true);
        }
    }

    public void ShowSelectedUnit(BaseUnit unit) {
        if (unit == null) {
            _selectedUnitObject.SetActive(false);
            return;
        }

        _selectedUnitObject.GetComponentInChildren<Text>().text = unit.name;
        _selectedUnitObject.SetActive(true);
    }
}