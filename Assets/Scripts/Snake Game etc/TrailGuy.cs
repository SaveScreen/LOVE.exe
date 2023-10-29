using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGuy : MonoBehaviour
{
    [HideInInspector] public float cadenDelay = 0.2f;
    private Vector2 oldPosition;
    private Vector2 tmpPosition;
    [HideInInspector] public GameObject leader;
    private bool inInfancy;


    //call in update
    private void SetOldPosition()
    {
        StartCoroutine(SetOldPositionRoutine());
    }

    private IEnumerator SetOldPositionRoutine()
    {
        //store a position in a tmp
        Vector2 tmpPos = new Vector2(tmpPosition.x, tmpPosition.y);

        //wait time before storing in real position
        yield return new WaitForSeconds(cadenDelay);
        oldPosition = tmpPos;
    }

    public void Spawn()
    {
        StartCoroutine(InfancyRoutine());
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator InfancyRoutine()
    {
        inInfancy = true;
        yield return new WaitForSeconds(cadenDelay);
        inInfancy = false;
    }

    private IEnumerator SpawnRoutine()
    {
        //when it's an infant, it doesnt know a good list of old values so
        //gets them from the leader temporarily
        //this breaks if the leader has a new child before this guy grows out of infancy

        while (inInfancy)
        {
            oldPosition = leader.GetComponent<SnakeScript>().GetOldPosition();
            //wait a frame
            yield return null;
        }
    }

    private void Start()
    {
        oldPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
    }

    private void Update()
    {
        tmpPosition = leader.transform.position;

        SetOldPosition();

        gameObject.transform.position =
                Vector2.MoveTowards(gameObject.transform.position, oldPosition, Time.deltaTime * 10f);
    }
}