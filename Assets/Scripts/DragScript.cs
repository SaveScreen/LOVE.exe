using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{

    Vector2 difference = Vector2.zero;

    //Collision stuff
    public Camera cam;
    public Transform DragObj;
    public GameObject Canvas;
    public float distanceFromCamera;
    Rigidbody r;
    [SerializeField] private float Speed;

    // Start is called before the first frame update
    private void Start()
    {
        distanceFromCamera = Vector3.Distance(DragObj.position, cam.transform.position);
        r = DragObj.GetComponent<Rigidbody>();
        Canvas.SetActive(false);
    }

    /*
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }
    */

    Vector3 lastPos;
    private void Update()
    {
        Speed = (r.velocity.x * r.velocity.y);
        if (Input.GetMouseButton (0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = cam.ScreenToWorldPoint(pos);
            r.velocity = (pos - DragObj.position) * 10;
           // lastPos = pos;
           // DragObj.position = pos;
        }
        if (Input.GetMouseButtonUp (0))
        {
            r.velocity = Vector3.zero;
        }
        /*
        if (Speed >= 1000)
        {
            Speed = 500;
        }
        if (Speed <= -1000)
        {
            Speed = -500;
        }
        */
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("killbox"))
        {
            Debug.Log("Hit Player");
            gameObject.SetActive(false);
            Canvas.SetActive(true);
        }

    }
}
