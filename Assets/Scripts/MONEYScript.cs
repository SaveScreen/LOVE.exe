using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONEYScript : MonoBehaviour
{

    public static int money = 0;
    
    public void AddMoney(int gainz)
    {
        money += gainz;
    }

    public int GetGAINZ()
    {
        return money;
    }


    void Start()
    {
        
    }
}
