using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// TODO: Provide a summary of your script here.
/// To create an auto-generated summary template
/// type 3 /// slash characters after you have
/// written your class or method signature.
/// </summary>
public class Soldier_Test : MonoBehaviour, Attackable
{
   
    private Mob_Test opponent = null;
    private Attackable target = null;

    /*private Queue<Attackable> targets;*/
    /**
        * TODO: General Structure Ideas:
        * 
        * Try to keep an order of fields from most complex to primitive.
        * GameObject go;
        * struct point;
        * float num;
        * bool truthy;
        * 
        * Constants before variables maybe too.
        * const int TIME_PLANNED_FOR_THIS
        * int timeSpentOnThis
        * 
        * Also from most public to private. Valid for methods too.
        * public
        * internal
        * protected
        * private
        * 
        *  Then only probably by alphabet. If at all
        */

    #region Serialized Fields

    //private float movementSpeed, effectiveRange, attackSpeed;
    //private int unitCost, damagePoints, healthPoints,goldGivenOnKill;
    //public MobType type;

    [SerializeField]
    protected SoldierData_Test mobData;

    
    protected float effectiveRange, movementSpeed, attackSpeed, attackTimer;
    

    protected int  healthPoints, goldGivenOnKill, resistance, evasionChance;

   /* protected float detectionRange = 15.0f;*/

    protected bool isMagic, isRanged, isFighting;
    private float originalSpeed;
    protected int attackDamage;

    #endregion Serialized Fields

    #region Fields



    #endregion Fields

    #region Built-Ins / MonoBehaviours

    // TODO: Put Unity built-in event methods here.
    // Such as Awake, Start, Update.
    // But also OnEnable, OnDestroy, OnTrigger and such.

    void Awake()
    {
       
    }

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isFighting)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer < 0)
            {
                attackTimer = 1 / attackSpeed;
                if (target != null)
                {
                    Attack(target);
                }
                else { 
                    isFighting = false;
                }
            }
            
        }
        transform.position = new Vector2(transform.position.x + movementSpeed * Time.deltaTime/10, 0f);
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {
        
    }

    #endregion Built-Ins / MonoBehaviours

    #region GetSets / Properties

    // TODO: Put Auto-Properties to your fields here.
    //
    // These are used for private fields as getters and setters.
    // Since they are very specific, they are down here.
    // The structure is (amost) always the same. Copy-Paste.

    /**
    public returnType FieldNameWithCapitalStart
    {
        get => fieldName;
        set => fieldName = value;
    }
    */

    #endregion GetSets / Properties

    #region Game Mechanics / Methods

    // TODO: Put your game specific mechanics here.
    // If they can be grouped by functionality, do so.

    /// <summary>
    /// TODO: Provide a summary for the method
    /// </summary>
    /// <param name="param">List the parameters.</param>
    /// <returns>Specify what it returns, if it does so.</returns>

    public void Initialize()
    {
        //effectiveRange = mobData.EffectiveRange;
        movementSpeed = Random.Range(mobData.MovementSpeed.min, mobData.MovementSpeed.max);
        attackSpeed = mobData.AttackSpeed;
        healthPoints = Random.Range(mobData.HealthPoints.min, mobData.HealthPoints.max);
        goldGivenOnKill = mobData.GoldGivenOnKill;
        attackDamage = mobData.AttackDamage;
        //attackStrength = mobData.AttackStrength;
        resistance = mobData.Resistance;
        evasionChance = mobData.EvasionChance;
        attackTimer = 1 / attackSpeed;

    }
    
   /* void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.name == 
    }*/
    
    public void Attacked(int damage, bool isMagic, bool isRanged)
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
        }
        //standard melee hits
        TakeDamage(damage - resistance);


        //throw new NotImplementedException();
    }
    public  void TakeDamage(int damage)
    {
        if (damage == 0)
        {
            Debug.Log("Missed the " + name + "!");
        }
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            UnitDeath();
        }
    }

    public void UnitDeath()
    {
        Debug.Log("DEAD!" + name);
        //Optional Death animation lol
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFighting) return;

        opponent = collision.gameObject.GetComponent<Mob_Test>();

        if (opponent != null)
        {
            isFighting = true;
            originalSpeed = movementSpeed;
            movementSpeed = 0.0f;

            if (opponent.GetOpponent() == null)
            {
                opponent.SetOpponent(this);
                opponent.SetIsFighting(true);
                /*opponent.InitiateCombat(this);*/
                
            }
           target = collision.gameObject.GetComponent<Attackable>();
          
        }    
        
    }
    private void Attack(Attackable target)
    {
        if (target != null)
        {
            int damage = attackDamage;       
            target.Attacked(damage, isMagic, isRanged);
            Debug.Log("I Just attacked :D");
        }
    }
  



    /*public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("FIGHTING!");
    }*/
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("FIGHT OVER!");
       
        isFighting = false;
        movementSpeed = originalSpeed;
    }
    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}