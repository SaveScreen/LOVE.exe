using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MONEYScript : MonoBehaviour
{

    public static int money = 500;
    
    public void AddMoney(int gainz)
    {
        money += gainz;
    }

    public void LoseMoney(int loss)
    {
        money -= loss;
    }

    public int GetGAINZ()
    {
        return money;
    }

    public void SetMoney(int amount) {
        money = amount;
    }


    void Start()
    {
        
    }
}
