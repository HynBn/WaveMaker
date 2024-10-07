using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CannonTower : Tower
{
    [SerializeField]
    private GameObject cannonball;

    private ParticleSystem outExplosion;

    private Vector3 cannonSpawnLocation;

    protected override void Start()
    {
        base.Start();
        outExplosion = GetComponentInChildren<ParticleSystem>();

        cannonSpawnLocation = new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z - 0.5f);
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
                // get closest target
                GameObject closestTarget = getClosestTarget();

                GameObject proj = Instantiate(cannonball, cannonSpawnLocation, transform.rotation);

                proj.GetComponent<CannonBall>().SetTarget(closestTarget, Random.Range(damage.min, damage.max));

                outExplosion.Play();

                AudioManager.Instance.PlaySfx("CannonOut");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attackable>() != null && collision.gameObject.GetComponent<IsFlying>() == null)
        {
            inRange.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Attackable>() != null && collision.gameObject.GetComponent<IsFlying>() == null)
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
