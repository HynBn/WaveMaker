using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    private float spawnRate = 1; // time in seconds between each spawn
    private float spawnTimer;
    private bool mobsLoaded = false;
    private Queue<string> mobs;

    [SerializeField]
    private GameObject goblin;
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    private GameObject slime;
    [SerializeField]
    private GameObject flying;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = spawnRate;
        mobs = new Queue<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mobsLoaded)
        {
            spawnTimer -= Time.deltaTime;

            if(spawnTimer < 0)
            {
                spawnTimer = spawnRate;

                if(mobs.Count > 0)
                {
                    GameObject prefab = null;
                    switch (mobs.Dequeue())
                    {
                        case "goblin":
                            prefab = goblin;
                            break;
                        case "wolf":
                            prefab = wolf;
                            break;
                        case "slime":
                            prefab = slime;
                            break;
                        case "flying":
                            prefab = flying;
                            break;
                    }
                    GameObject obj = Instantiate(prefab, transform);
                    //Mob mob = obj.GetComponent<Mob>();
                    //GameData.gold -= mob.UnitCost;
                }
                else
                {
                    mobsLoaded = false;
                } 
            }
        }
    }

    // this method needs a list of mob gameobjects to spawn
    public void LoadMobs(string[] mobList)
    {
        foreach (string mob in mobList)
        {
            if(mob != "")
            {
                mobs.Enqueue(mob);
            }
        }
        mobsLoaded = true;
    }
}
