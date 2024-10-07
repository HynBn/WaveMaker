using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTarget2 : MonoBehaviour, Attackable
{
    public void Attacked(int damage, bool isMagic, bool isRanged)
    {
        Debug.Log("Got attacked! 2");
    }


    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.right * 5 * Time.deltaTime);
    }

}
