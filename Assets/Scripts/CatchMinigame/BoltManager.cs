using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltManager : MonoBehaviour
{
    /*
    public static BoltManager instance;

    [SerializeField]
    public List<GameObject> boltsPrefabs = null;

    public float currentFallingSpeed;

    private float normalFallingSpeed = 3f;

    private BoltSpawnHelper spawnHelper;

    private readonly float spawningSpeed = 1f;

    private void Awake()
    {
        SinglePattern();
        spawnHelper = gameObject.AddComponent<BoltSpawnHelper>();
        ResetFallingSpeed();
    }

    public void ResetFallingSpeed()
    {
        currentFallingSpeed = normalFallingSpeed;
    }

    private void Start()
    {
        StartCoroutine(spawnBolts());
    }

    private IEnumerator spawnBolts()
    {
        while (1 == 1)
        {
            yield return new WaitForSeconds(spawningSpeed);

            SpawnMoreBolts();
        }
    }

    private void SpawnMoreBolts()
    {
        for(int i = 0; i < Random.Range (2,3); i++)
            {
                spawnHelper.spawnBolts();
            }
    }

    public void HideBolts()
    {
        StopAllCoroutines();
        foreach (GameObject bolt in GameObject.FindGameObjectsWithTag("Bolt"))
        {
            bolt.GetComponent<Bolt>().Hide();
        }
    }



    private void SinglePattern()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(gameObject);
        }
    }

    */
    
}
