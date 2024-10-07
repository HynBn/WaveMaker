using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    private float speed = 4;
    private Vector3 direction;
    private GameObject destinationObject;
    private Vector3 destination;
    private int damage;

    private bool hasTarget = false;
    
    private ParticleSystem magic;

    void Start()
    {
        magic = GetComponentInChildren<ParticleSystem>();
        magic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasTarget)
        {
            if (destinationObject != null)
            {
                destination = new Vector3(destinationObject.transform.position.x, destinationObject.transform.position.y, transform.position.z);
            }
            // set the direction
            direction = destination - transform.position;

            // move towards the direction
            transform.Translate(Vector3.Normalize(direction) * speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, destination) < 0.05)
            {
                if (destinationObject != null)
                {
                    destinationObject.GetComponent<Attackable>().Attacked(damage, true, true);
                }
                AudioManager.Instance.PlaySfx("IceSpellHit");
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
