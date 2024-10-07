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
public class Soldier : MonoBehaviour, Attackable
{

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
    protected MobData mobData;

    
    protected float effectiveRange, movementSpeed, attackSpeed;

 
    protected int  healthPoints, goldGivenOnKill, resistance, evasionChance;


    protected bool isFlying, isMagic, isRanged, isFighting;
    private float originalSpeed;
    protected StatRange attackStrength;
    private Coroutine fightingCoroutine;

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
    void Update()
    {
        
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
        //attackSpeed = Random.Range(mobData.AttackSpeed.min, mobData.AttackSpeed.max);
        healthPoints = Random.Range(mobData.HealthPoints.min, mobData.HealthPoints.max);
        goldGivenOnKill = mobData.GoldGivenOnKill;
        isFlying = mobData.IsFlying;
        //attackStrength = mobData.AttackStrength;
        resistance = mobData.Resistance;
        evasionChance = mobData.EvasionChance;
    }

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

    /*public void OnTriggerEnter2D(Collider2D collision)
    {
        if (isFighting) return;

        Mob opponent = collision.gameObject.GetComponent<Mob>();

        if (opponent != null)
        {
            isFighting = true;
            originalSpeed = movementSpeed;
            movementSpeed = 0.0f;

            if (opponent.GetOpponent() == null)
            {
                opponent.SetOpponent(this);
                opponent.SetIsFighting(true);
                opponent.InitiateCombat(this);
                
            }
            Attackable target = collision.gameObject.GetComponent<Attackable>();
            if (target != null)
                fightingCoroutine = StartCoroutine(Attack(target));
                   
                
                
        }
    }*/

    private IEnumerator Attack(Attackable target)
    {
       
        
        
        yield return new WaitForSeconds(1.0f / (attackSpeed / 10.0f));

        if (target == null)
            StopAllCoroutines();

        if (target != null)
        {
            int damage = Random.Range(attackStrength.min, attackStrength.max);
            if (target != null)
            {
                target.Attacked(damage, isMagic, isRanged);
                StartCoroutine(Attack(target));
            }
        }
        else
        {
            StopAllCoroutines();
            isFighting = false;
            movementSpeed = originalSpeed;

        }
    }



    /*public void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("FIGHTING!");
    }*/
    public void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("FIGHT OVER!");
        StopCoroutine(fightingCoroutine);
        isFighting = false;
        movementSpeed = originalSpeed;
    }
    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}