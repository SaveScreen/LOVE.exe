using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMovement : MonoBehaviour
{
    private const int targetY = -20;
    Vector3 target;
    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        target = transform.position;
        target.y = targetY;
    }

    void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        float step = BoltManager.instance.currentFallingSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    public void Hide()
    {
        transform.position = target;
        gameObject.SetActive(false);
    }

    private void OnBecameInvisible()
    {
        if(transform.position.y > ScreenHelper.ScreenTop) { return; }
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag("Player")) { return; }

        transform.position = target;
        gameObject.SetActive(false);
        //LevelManager.instance.BoltCatch(BoltType);
    }
}
