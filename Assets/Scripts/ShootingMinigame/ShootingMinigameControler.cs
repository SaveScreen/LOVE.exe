using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShootingMinigameControler : MonoBehaviour
{
    Camera cam;
    public GameObject prefab;
    public TargetScript Script;
    public TargetScript[] targets;
    public List<TargetScript> myTargets = new();

    public bool waitover;

    public void ResetTargets()
    {
        if(waitover)
        {
            foreach(TargetScript target in myTargets)
            {
                target.Reactivate();
                Debug.Log("all reactivated");
                waitover = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        print(cam.name);
        TargetScript target = gameObject.GetComponent<TargetScript>();
        waitover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit = new RaycastHit();

            if (Physics.Raycast(cameraRay, out Hit))
            {
                if (Hit.collider.CompareTag("ShootTarget"))
                {
                    Debug.Log("hit target");
                    
                    Hit.collider.gameObject.GetComponent<TargetScript>().AddScore();
                    //target.GetComponent<TargetScript>().AddScore();
                }
                else
                {
                    Debug.Log("missed");
                }
            }
        }
        
        foreach (TargetScript obj in targets) {
        if (targets.All(obj => obj.Iwashit)) // or .Any to test for ... "any"
        {
            //timer.StopTimer();
               StartCoroutine(ResetAllCoroutine());
                ResetTargets();
        }
        }
        
    }

    public IEnumerator ResetAllCoroutine()
    {
        while(!waitover)
        {
         Debug.Log("Started Coroutine at timestamp : " + Time.time);
         yield return new WaitForSeconds(1);
         Debug.Log("Finished Coroutine at timestamp : " + Time.time);
                 waitover = true;
                  yield return null;

        }
    }
}
