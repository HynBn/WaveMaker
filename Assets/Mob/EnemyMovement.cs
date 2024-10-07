using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //private Rigidbody2D myRigidbody;

    private float moveSpeed = 2f; //The Speed defined by the Enemy speed property

    [SerializeField] private Mob mob;

    private Transform target;

    private int Index = 0;

    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        target = LevelManager.main.path[Index];
        //myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveSpeed = mob.MovementSpeed;

        updateAnimation();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            Index++;

            if (Index == LevelManager.main.path.Length)
            {
                Destroy(gameObject);
                return;
            }
            else
            {
                target = LevelManager.main.path[Index];

                updateAnimation();

            }

        }

            

        Vector3 direction = Vector3.Normalize(target.position - transform.position);

        //myRigidbody.velocity = moveSpeed * Time.deltaTime * direction;
        transform.Translate(moveSpeed * Time.deltaTime * direction / 100);
    }

    private void updateAnimation()
    {
        Vector3 animDirection = Vector3.Normalize(target.position - transform.position);
        if (Mathf.Abs(animDirection.x) > Mathf.Abs(animDirection.y))
        {
            if (animDirection.x < 0)
            {
                //walk left
                animator.Play("walk_left");
            }
            else
            {
                //walk right
                animator.Play("walk_right");
            }
        }
        else
        {
            if (animDirection.y < 0)
            {
                //walk down
                animator.Play("walk_down");
            }
            else
            {
                //walk up
                animator.Play("walk_up");
            }
        }
    }
}
