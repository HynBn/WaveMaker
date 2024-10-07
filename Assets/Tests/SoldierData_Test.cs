using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoldierData_Test", menuName = "ScriptableObjects/Soldier Data_Test", order = 2)]
/// <summary>
/// TODO: Provide a summary of your script here.
/// To create an auto-generated summary template
/// type 3 /// slash characters after you have
/// written your class or method signature.
/// </summary>
public class SoldierData_Test : ScriptableObject
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
    protected int goldGivenOnKill;

    [SerializeField]
    protected StatRange healthPoints, movementSpeed;

    [SerializeField]
    protected int resistance, evasionChance, attackDamage;

    [SerializeField]
    protected float attackSpeed;
   
    
 
    





    //public MobType type;


    #endregion Serialized Fields

    #region GetSets / Properties

    public StatRange HealthPoints { get => healthPoints; }
    //public StatRange AttackStrength { get => attackStrength; }
    public StatRange MovementSpeed { get => movementSpeed; }
    public float AttackSpeed { get => attackSpeed; }

    
    public int GoldGivenOnKill { get => goldGivenOnKill; }
    public int Resistance { get => resistance; }
    public int EvasionChance { get => evasionChance; }
    public int AttackDamage { get => attackDamage; }
    
   


    #endregion GetSets / Properties

    #region Game Mechanics / Methods




    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}