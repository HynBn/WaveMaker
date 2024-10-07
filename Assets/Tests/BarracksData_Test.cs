using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BarracksData_Test", menuName = "ScriptableObjects/Barracks Data_Test", order = 2)]
/// <summary>
/// TODO: Provide a summary of your script here.
/// To create an auto-generated summary template
/// type 3 /// slash characters after you have
/// written your class or method signature.
/// </summary>
public class BarracksData_Test : ScriptableObject
{
    public int buildingCost, numberOfSoldiers, barracksTier, towerRange;

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



   /* [SerializeField]
    protected override int buildingCost, numberOfSoldiers, barracksTier, towerRange;*/








    //public MobType type;


    #endregion Serialized Fields

    #region GetSets / Properties

 

    public int BuildingCost { get => buildingCost; }

    public int NumberOfSoldiers { get => numberOfSoldiers; }
    public int BarracksTier { get => barracksTier; }
    public int TowerRange { get => towerRange; }




    #endregion GetSets / Properties

    #region Game Mechanics / Methods




    #endregion Game Mechanics / Methods

    #region Overarching Methods / Helpers

    // TODO: Put your helper methods here.

    #endregion Overarching Methods / Helpers
}