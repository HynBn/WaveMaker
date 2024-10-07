using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BarracksTower_Test : MonoBehaviour
{
    private int soldiersPerGroup;
    protected GroupOfSoldiers_Test soldiers;
    [SerializeField]
    protected BarracksData_Test barracksData;
    protected float respawnCooldown;
   
    /* private Animator animator;*/


    protected void Start()
    {
        
        
        /*animator = GetComponentInChildren<Animator>();*/
    }

    // Update is called once per frame
    protected  void Update()
    {

        float respawnTimer = respawnCooldown;
        respawnTimer -= Time.deltaTime;
        if (respawnTimer< 0)
        {
            respawnTimer = respawnCooldown;
            if (soldiers.currentSoldierCount() < soldiersPerGroup)
            {
                Soldier_Test soldier = new Soldier_Test();
                soldiers.addSoldierToGroup(soldier);
                               
                /*ar.GetComponent<Arrow>().SetTarget(closestTarget, Random.Range(damage.min, damage.max));*/

               /* AudioManager.Instance.PlaySfx("ArrowOut");*/

                /*Vector3 direction = Vector3.Normalize(closestTarget.transform.position - animator.transform.position);

                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x < 0)
                    {
                        animator.Play("ArcherAttackLeft");
                    }
                    else
                    {
                        animator.Play("ArcherAttackRight");
                    }
                }
                else
                {
                    if (direction.y < 0)
                    {
                        animator.Play("ArcherAttackFront");
                    }
                    else
                    {
                        animator.Play("ArcherAttackBack");
                    }
                }*/
            }
        }



    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.GetComponent<Attackable>() != null)
        {
            inRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attackable>() != null)
        {
            inRange.Remove(collision.gameObject);
        }
    }*/

    // returns the closest gameObject in inRange to this tower
    /*private GameObject getClosestTarget()
    {
        GameObject target = inRange[0];
        float minDistace = Vector3.Distance(gameObject.transform.position, target.transform.position);
        foreach (GameObject g in inRange)
        {
            float gDistance = Vector3.Distance(gameObject.transform.position, g.transform.position);
            if (minDistace > gDistance)
            {
                target = g;
                minDistace = gDistance;
            }
        }
        return target;
    }*/
}
