using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MobData", menuName = "ScriptableObjects/Mob Data", order = 2)]
/// <summary>
/// TODO: Provide a summary of your script here.
/// To create an auto-generated summary template
/// type 3 /// slash characters after you have
/// written your class or method signature.
/// </summary>
public class MobData : ScriptableObject
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



    [SerializeField]
    protected int unitCost, goldGivenOnKill;

    [SerializeField]
    protected bool isFlying;

    [SerializeField]
    protected StatRange healthPoints, movementSpeed;

    [SerializeField]
    protected int resistance, evasionChance;
    
 
    





    //public MobType type;


    #endregion Serialized Fields

    #region GetSets / Properties

    public StatRange HealthPoints { get => healthPoints; }
    //public StatRange AttackStrength { get => attackStrength; }
    public StatRange MovementSpeed { get => movementSpeed; }

    public int UnitCost { get => unitCost; }
    
    public int GoldGivenOnKill { get => goldGivenOnKill; }
    public bool IsFlying { get => isFlying;}
    public int Resistance { get => resistance; }
    public int EvasionChance { get => evasionChance; }
   


    #endregion GetSets / Properties

    #region Game Mechanics / Methods




    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}