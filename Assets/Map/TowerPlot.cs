using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlot : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer sr;

    private GameObject tower;

    private void OnMouseDown()
    { 
        Debug.Log("Build tower here");
    }
}
