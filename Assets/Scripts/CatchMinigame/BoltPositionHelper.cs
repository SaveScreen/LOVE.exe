using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltPositionHelper : MonoBehaviour
{
    
    Vector3 lastSpawnPoint;

    private readonly float SpawnMinDistance = 1f;


    public Vector3 GetSpawnPosition()
    {
        Vector3 newSpawnPoint = new Vector3(Random.Range(ScreenHelper.ScreenLeft, ScreenHelper.ScreenRight), ScreenHelper.ScreenTop + Random.Range(3, 7));

        if(Vector3.Distance(newSpawnPoint, lastSpawnPoint) > SpawnMinDistance)
        {
            lastSpawnPoint = newSpawnPoint;
            return newSpawnPoint;
        }
        else
        {
            return GetSpawnPosition();
        }
    }
    
}
