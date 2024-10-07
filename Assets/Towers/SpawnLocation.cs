using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SpawnLocation : MonoBehaviour
{
    public bool isOccupied;

    private void Start()
    {
        isOccupied = false;
    }
}
