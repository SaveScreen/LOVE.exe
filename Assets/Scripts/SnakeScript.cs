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
    [SerializeField] private float Speed;

    //Snake Stuff
    
    private List<Transform> _segments;

    public Transform killboxPrefab;

    public GameObject go;
    public Transform Head;
    private float behindDistance = 1;

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
    }

    private void FixedUpdate()
    {
        for (int i= _segments.Count - 1; i > 0; i--)
        {
            _segments[1].position = _segments[i - 1].position;
        }
        
    }

    
    private void Grow()
    {
        Transform segment = Instantiate(this.killboxPrefab);
        segment.position = Head.position - (Head.forward * behindDistance);  //_segments[_segments.Count - 1].position;
        
        _segments.Add(segment);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("killbox"))
        {
            Debug.Log("Hit Player");
            gameObject.SetActive(false);
            Canvas.SetActive(true);
        }

        if (other.tag == "SnakeFood")
        {
            Grow();
        }
    }
}
