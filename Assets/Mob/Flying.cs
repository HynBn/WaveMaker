using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Flying : Mob, Attackable, IsFlying
{
    private Animator animator;


    void Awake()
    {
        base.Initialize();
    }

   
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Attacked(int damage, bool isMagic, bool isRanged)
    {

        if (isMagic)
        {
            TakeDamage(damage);
            return;
        }
        if (isRanged && !isMagic)
        {
            int evasionNumber = Random.Range(1, 101);
            int critChance = Random.Range(1, 1000);
            if (evasionNumber <= evasionChance)
            {
                TakeDamage(0);
                return;
            }
            if (critChance <= 10)
            {
                Debug.Log("CRIT!");
                TakeDamage(damage * 2);
                return;
            }
            TakeDamage(damage - resistance);

        }

    }
    public override void TakeDamage(int damage)
    {
        if (damage == 0)
        {
            Debug.Log("Miss!");
        }
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            //UnitDeath();
            animator.Play("death");
        }
    }

    public override void UnitDeath()
    {
        //Optional Death animation lol
        AudioManager.Instance.PlaySfx("coinDrop");
        UpdateGameData();
        Destroy(gameObject);
    }
    
}