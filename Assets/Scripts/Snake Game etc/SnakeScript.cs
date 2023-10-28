using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript1 : MonoBehaviour
{

    Vector2 difference = Vector2.zero;

    //Collision stuff
    public Camera cam;
    public Transform DragObj;
    public GameObject Canvas;
    public float distanceFromCamera;
    Rigidbody r;

    //Snake Stuff

    private List<Transform> _segments;

    public Transform killboxPrefab;
  

    // Start is called before the first frame update
    private void Start()
    {
        distanceFromCamera = Vector3.Distance(DragObj.position, cam.transform.position);
        r = DragObj.GetComponent<Rigidbody>();
        Canvas.SetActive(false);

        _segments = new List<Transform>();
        _segments.Add(this.transform);
    }

    Vector3 lastPos;
    private void Update()
    {
        
    }

    //this is supposed to track the positions of each segment in reverse order, spawning at the end of the sequence
    private void FixedUpdate()
    {

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Input.mousePosition;
            pos.z = distanceFromCamera;
            pos = cam.ScreenToWorldPoint(pos);
            r.velocity = (pos - DragObj.position) * 10;
            // lastPos = pos;
            // DragObj.position = pos;
        }
        if (Input.GetMouseButtonUp(0))
        {
            r.velocity = Vector3.zero;
        }
        //Looks in direction u r moving
        Quaternion rotation = Quaternion.LookRotation(r.velocity, Vector3.up);
        transform.rotation = rotation;
    }

    //adds a segment
    private void Grow()
    {
        Transform segment = Instantiate(this.killboxPrefab);
        segment.position = _segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }

    private void OnTriggerEnter(Collider other)
    {
        /*
        if (other.gameObject.CompareTag("killbox"))
        {
            Debug.Log("Hit Player");
            gameObject.SetActive(false);
            Canvas.SetActive(true);
        }
        */

        //snakefood == green box
        if (other.tag == "SnakeFood")
        {
            Invoke("Grow", .1f);
        }
    }
}
