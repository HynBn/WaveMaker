using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArcherTower : Tower
{
    [SerializeField]
    private GameObject arrow;

    private Animator animator;


    protected override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    protected override void Update()
    {

        base.Update();
        attackTimer -= Time.deltaTime;
        if (attackTimer < 0)
        {
            attackTimer = 1 / attackSpeed;
            if (inRange.Count > 0)
            {
                GameObject closestTarget = getClosestTarget();
                GameObject ar = Instantiate(arrow, animator.transform);
                ar.GetComponent<Arrow>().SetTarget(closestTarget, Random.Range(damage.min, damage.max));

                AudioManager.Instance.PlaySfx("ArrowOut");

                Vector3 direction = Vector3.Normalize(closestTarget.transform.position - animator.transform.position);

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
                }
            }
        }
        
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
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
    }

    // returns the closest gameObject in inRange to this tower
    private GameObject getClosestTarget()
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
    }
}
