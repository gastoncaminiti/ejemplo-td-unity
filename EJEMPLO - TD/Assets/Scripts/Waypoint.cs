using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject towerPrefab;
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
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
