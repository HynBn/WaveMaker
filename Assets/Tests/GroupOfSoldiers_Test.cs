using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupOfSoldiers_Test : MonoBehaviour
{
    protected int numberOfSoldiers;
    protected Vector2 barracksLocation;
    protected Vector2 setLocation;
    protected List<Soldier_Test> soldiersInGroup = new List<Soldier_Test>();

    public GroupOfSoldiers_Test(int soldierNumber, Vector2 location)
    {
        this.numberOfSoldiers = soldierNumber;
        this.setLocation = location;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addSoldierToGroup(Soldier_Test soldier)
    {
        soldiersInGroup.Add(soldier);
    }
    private void spawnSoldier(Soldier_Test soldier)
    {
        Instantiate(new Soldier_Test(), barracksLocation, Quaternion.identity);
    }
    private void moveSoldierToSetLocation()
    {

    }


    public int currentSoldierCount()
    {
        return soldiersInGroup.Count;
    }
    public void set_numberOfSoliders(int number)
    {
        this.numberOfSoldiers = number;
    }
    public int get_numberOfSoldiers()
    {
        return this.numberOfSoldiers;
    }
    public void set_setLocation(Vector2 location)
    {
        this.setLocation = location;
    }
    public Vector2 get_setLocation()
    {
        return this.setLocation;
    }
}
