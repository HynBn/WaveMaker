using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    Transform sprite;

    private float speed = 15;
    private Vector3 direction;
    private GameObject destinationObject;
    private Vector3 destination;
    private int damage;

    private bool hasTarget = false;
    // Start is called before the first frame update
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

            // change rotation based on direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            sprite.rotation = Quaternion.Euler(0, 0, angle);

            // move towards the direction
            transform.Translate(Vector3.Normalize(direction) * speed * Time.deltaTime);

            if(Vector3.Distance(transform.position, destination) < 0.05)
            {
                if ( destinationObject != null )
                {
                    destinationObject.GetComponent<Attackable>().Attacked(damage, false, true);
                }

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
