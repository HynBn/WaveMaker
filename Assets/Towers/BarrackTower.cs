/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrackTower : Tower
{
    [SerializeField]
    private GameObject soldier;

    protected override void Start()
    {
        base.Start(); 
        getNearbyPath();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base .Update();
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            attackTimer = 1 / attackSpeed;
            if (inRange.Count > 0)
            {
                GameObject closestTarget = getClosestTarget();
                if (closestTarget != null)
                {
                    closestTarget.GetComponent<SpawnLocation>().isOccupied = true;
                    GameObject sol = Instantiate(soldier, closestTarget.transform.position, closestTarget.transform.rotation);
                    sol.GetComponent<SoldierSpawnOcc>().setSpawnLocation(closestTarget);
                }
            }
        }
    }

    // gets the closest spawnlocation that is not occupied, if all nearby locartions are occupied null is returned
    private GameObject getClosestTarget()
    {
        GameObject target = null;
        foreach (GameObject g in inRange)
        {
            if (!g.GetComponent<SpawnLocation>().isOccupied)
            {
                target = g; break;
            }
        }

        if(target != null)
        {
            float minDistace = Vector3.Distance(gameObject.transform.position, target.transform.position);
            foreach (GameObject g in inRange)
            {
                if(!g.GetComponent<SpawnLocation>().isOccupied)
                {
                    float gDistance = Vector3.Distance(gameObject.transform.position, g.transform.position);
                    if (minDistace > gDistance)
                    {
                        target = g;
                        minDistace = gDistance;
                    }
                } 
            }
            return target;
        }
        return null;
    }

    // get all path tiles nearby
    private void getNearbyPath()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, range);

        // check if collisions are path
        foreach (Collider2D coll in collisions)
        {
            if(coll.gameObject.GetComponent<SpawnLocation>() != null)
            {
                inRange.Add(coll.gameObject);
            }
        }
    }
}
*/