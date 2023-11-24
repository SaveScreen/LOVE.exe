using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingMinigameControler : MonoBehaviour
{
    Camera cam;
    public GameObject target;
    public TargetScript Script;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        print(cam.name);
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
    }

}
