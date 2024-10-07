using System.Collections.Generic;
using UnityEngine;

public class BuilderAI : MonoBehaviour
{ 
    [SerializeField] private List<TowerSettings> towers;
    private List<GameObject> plots;
    private Transform plotContainer;

    private float waitTimer;

    void Start()
    {
        plotContainer = GameObject.Find("TowerPlots").transform;
        waitTimer = Random.Range(2, 5);
        plots = GetPlots();
    }

    void Update()
    {
        if (!GameData.isRunning) return;

        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            return;
        }
        BuildTower();
    }

    private void BuildTower()
    {
        TowerSettings tower = PickTower();
        if (GameData.enemyGold < tower.cost) return;
        Instantiate(tower.prefab, PickPlot(), Quaternion.identity, plotContainer);
        GameData.enemyGold -= tower.cost;
        
        waitTimer = Random.Range(3, 10);
    }

    private Vector3 PickPlot()
    {
        GameObject plot = plots[Random.Range(0, plots.Count)];
        Vector3 position = plot.transform.position;
        plots.Remove(plot);
        Destroy(plot);
        return position;
    }

    private TowerSettings PickTower()
    {
        return towers[Random.Range(0, towers.Count)];
    }
    private List<GameObject> GetPlots()
    {
        List<GameObject> result = new();
        for (int i = 0; i < plotContainer.childCount; i++)
        {
            result.Add(plotContainer.GetChild(i).gameObject);
        }
        return result;
    }
}