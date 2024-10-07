using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTower", menuName = "ScriptableObjects/Tower")]
public class TowerSettings : ScriptableObject
{
    public string type;
    public StatRange damage;
    public int cost;
    public float range;
    public float attackSpeed;
    public Sprite sprite;
    public GameObject prefab;
}
