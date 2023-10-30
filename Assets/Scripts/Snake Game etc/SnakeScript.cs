using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SnakeScript : MonoBehaviour
{

    Vector2 difference = Vector2.zero;

    //Collision stuff
    public Camera cam;
    public Transform DragObj;
    public GameObject Canvas;
    public float distanceFromCamera;
    Rigidbody r;

    //Score
    public TextMeshProUGUI scoretext;
    public float score;

    //Snake Stuff
    private List<Transform> _segments;
    public Transform killboxPrefab;

    //Caden Help Stuff
    private bool didWin;
    private int gamecount;
    public GameObject playerdatacontainer;
    private PlayerData playerdata;
    public TextMeshProUGUI wintext;


    // ethanDelay = time between first little guy spawn
    [SerializeField] private float ethanDelay = 0.1f;

    // ethanDelayDelta = amount of time added to ethanDelay
    [SerializeField] private float ethanDelayDelta = 0.05f;
    Vector2 oldPosition;
    Vector2 tmpPosition;

    //debug obj to spawn
    public GameObject cloneObj;

    public List<GameObject> littleGuys;

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
        yield return new WaitForSeconds(ethanDelay);
        oldPosition = tmpPos;
    }

    public Vector2 GetOldPosition()
    {
        return oldPosition;
    }

    private void Update()
    {
        tmpPosition = gameObject.transform.position;
        SetOldPosition();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        scoretext.text = "Score: " + score;
    }

    Vector3 lastPos;
    // Start is called before the first frame update
    private void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();

        oldPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        distanceFromCamera = Vector3.Distance(DragObj.position, cam.transform.position);
        r = DragObj.GetComponent<Rigidbody>();
        Canvas.SetActive(false);

        _segments = new List<Transform>();
        _segments.Add(this.transform);

        scoretext.text = "Score: ";
        gamecount = playerdata.GetGameCount();

        switch (gamecount)
        {
            case 0:
                wintext.text = "Score at least 10 to pass!";
                break;
            case 1:
                wintext.text = "Score at least 20 to pass!";
                break;
            case 2:
                wintext.text = "Score at least 30 to pass!";
                break;
        }


    }
    //this is supposed to track the positions of each segment in reverse order, spawning at the end of the sequence
    private void FixedUpdate()
    {
        /*
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }
        */

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
        ethanDelay += ethanDelayDelta;
        littleGuys.Add(Instantiate(cloneObj));
        littleGuys[littleGuys.Count - 1].GetComponent<TrailGuy>().cadenDelay = ethanDelay;
        littleGuys[littleGuys.Count - 1].GetComponent<TrailGuy>().leader = gameObject;
        littleGuys[littleGuys.Count - 1].transform.position = oldPosition;
        littleGuys[littleGuys.Count - 1].GetComponent<TrailGuy>().Spawn();

        //Transform segment = Instantiate(this.killboxPrefab);
        //segment.position = _segments[_segments.Count - 1].position;
        //segment.position = oldPosition;

        //_segments.Add(segment);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("killbox"))
        {
            Debug.Log("Hit Player");
            gameObject.SetActive(false);
            Canvas.SetActive(true);
            scoretext.text = "Score: " + score;

            switch (gamecount)
            {
                case 0:
                    if (score >= 10)
                    {
                        didWin = true;
                    }
                    else
                    {
                        didWin = false;
                    }
                    break;
                case 1:
                    if (score >= 20)
                    {
                        didWin = true;
                    }
                    else
                    {
                        didWin = false;
                    }
                    break;
                case 2:
                    if (score >= 30)
                    {
                        didWin = true;
                    }
                    else
                    {
                        didWin = false;
                    }
                    break;
            }

        }
        

        //snakefood == green box
        if (other.tag == "SnakeFood")
        {
            Invoke("Grow", .4f);
            AddScore();
        }

    }
    public void AddScore()
    {
        score += 1;
    }

    public void GoToDate()
    {
        playerdata.UpdatePlayerDateScore(didWin);
        playerdata.IncreaseGameCount();

        if (didWin)
        {
            playerdata.WonGame();
        }
        else
        {
            playerdata.LostGame();
        }
        
        SceneManager.LoadScene("VisualNovel");

    }
    public void Restart()
    {
        SceneManager.LoadScene("SnakeMinigame");
    }
}
