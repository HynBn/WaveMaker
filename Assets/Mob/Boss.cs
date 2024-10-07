
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TODO: Provide a summary of your script here.
/// To create an auto-generated summary template
/// type 3 /// slash characters after you have
/// written your class or method signature.
/// </summary>
public class Boss : Mob
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

    //public MobData data;



    #endregion Serialized Fields

    #region Fields

    // TODO: Put general non-serialized fields here.

    #endregion Fields

    #region Built-Ins / MonoBehaviours

    // TODO: Put Unity built-in event methods here.
    // Such as Awake, Start, Update.
    // But also OnEnable, OnDestroy, OnTrigger and such.

    void Awake()
    {
        // base.SetUp();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
            TakeDamage(damage - this.resistance);

        }
        TakeDamage(damage - resistance);


        //throw new NotImplementedException();
    }
    public override void TakeDamage(int damage)
    {
        if (healthPoints == 0)
        {
            Debug.Log("Miss!");
        }
        healthPoints -= damage;
        if (healthPoints <= 0)
        {
            UnitDeath();
        }
    }

    public override void UnitDeath()
    {
        //Optional Death animation lol
        Destroy(gameObject);
    }

    
    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}