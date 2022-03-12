using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;
    public bool IsPlaceable { get { return isPlaceable; } }

    /*METHOD FOR DO SOMETHING -> PROPERTIES ARE BETTER
    public bool GetIsPlaceable()
    {
        return isPlaceable;
    }
    */

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            bool isPlace = towerPrefab.CreateTower(towerPrefab, transform.position);
            isPlaceable = !isPlace;
        }
    }
}
