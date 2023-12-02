using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchingScript : MonoBehaviour
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
        target.y= targetY;
    }
    void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        float step = 2f * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);

    }
    
    private void OnBecameInvisible()
    {
        if(transform.position.y > ScreenHelper.ScreenTop) { return; }
        gameObject.SetActive(false);
    }
}
