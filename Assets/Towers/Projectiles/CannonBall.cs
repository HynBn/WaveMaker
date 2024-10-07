using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    private float speed = 10;
    private Vector3 direction;
    private GameObject destinationObject;
    private Vector3 destination;
    private int damage;

    private float aoe = 1;

    private bool hasTarget = false;

    [SerializeField]
    private GameObject explosion;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            if (destinationObject != null)
            {
                destination = destinationObject.transform.position;
            }
            // set the direction
            direction = destination - transform.position;

            // move towards the direction
            transform.Translate(Vector3.Normalize(direction) * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination) < 0.05)
            {

                // get all colliders around the closestTarget in an aoe
                Collider2D[] targets = Physics2D.OverlapCircleAll(destination, aoe);

                // check if the targets in the array are attackables
                foreach (Collider2D target in targets)
                {
                    if (target.gameObject.GetComponent<Attackable>() != null && target.gameObject.GetComponent<IsFlying>() == null)
                    {
                        target.GetComponent<Attackable>().Attacked(damage, false, true);
                    }
                }
               GameObject expl = Instantiate(explosion, transform.position, transform.rotation);
               expl.GetComponent<ParticleSystem>().Play();
               Destroy(gameObject);
            }
        }
    }

    public void SetTarget(GameObject g, int d)
    {
        destinationObject = g;
        hasTarget = true;
        damage = d;
    }
}
