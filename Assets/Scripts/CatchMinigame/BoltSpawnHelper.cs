using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltSpawnHelper : MonoBehaviour
{
    
    private BoltPositionHelper positionHelper;

    private List<GameObject> spawnedBolts = new List<GameObject>();

    private void Awake()
    {
        positionHelper = new BoltPositionHelper();
    }

   public void spawnBolts()
    {
        if(BoltSpawnVisible())
        {
            Reuse();
        }
        else
        {
            Spawn();
        }
     
    }

    private bool BoltSpawnVisible()
    {
        return spawnedBolts.Exists(x => !x.activeSelf && x != null);
    }

    private void Spawn()
    {
        
            GameObject spawnedBolts = Instantiate(getRandomBolt(), positionHelper.GetSpawnPosition(), Quaternion.identity);
            spawnedBolts.Add(spawnedBolts);
        
    }

    private void Reuse()
    {
      GameObject boltReuse = spawnedBolts.Find(x => !x.activeSelf && x != null);
      boltReuse.SetActive(true);
      boltReuse.transform.position = positionHelper.GetSpawnPosition();
      boltReuse.GetComponent<Bolt>().Reset();
    }

    GameObject getRandomBolt()
    {
        return BoltManager.instance.boltsPrefabs[Random.Range(0, BoltManager.instance.boltsPrefabs.Count)];
    }

    

}
