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
    public GameObject gameovercanvas; //Canvas for gameover
    public GameObject endlessgameover;
    public GameObject endlessgamewon;
    public float distanceFromCamera;
    Rigidbody r;

    //Score
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI hiscoretext;
    public int score;
    private int hiscore;

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
    public GameObject christmasCloneObj;

    public List<GameObject> littleGuys;

    //Stuff for Endless Mode
    private int snakegamesplayed;
    private bool isendlessmode;
    private int potentialscore;
    private bool endlesscomplete;

    //audio Stuff
    public AudioSource audioSource;
    public AudioSource musicPlayer;
    public AudioClip pickup;
    public AudioClip died;
    public AudioClip win;
    private bool gamestarted;
    [SerializeField] private float timer;
    public TextMeshProUGUI countdowntimer;
    private int timerinseconds;

    public GameObject regularbg;
    public GameObject christmasbg;
    public GameObject regularfood;
    public GameObject christmasfood;
    private bool isChristmas;

    public void PlaySound(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }

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
        if (!gamestarted) {
            timer -= Time.deltaTime;
            countdowntimer.text = timerinseconds.ToString();
            if (timer < 3 && timerinseconds == 0) {
                timerinseconds = 3;
            }
            else if (timer < 2 && timerinseconds == 3) {
                timerinseconds = 2;
            }
            else if (timer < 1 && timerinseconds == 2) {
                timerinseconds = 1;
            }
            else if (timer < 0 && timerinseconds == 1) {
                timer = 0;
                countdowntimer.text = "GO!";
                StartCoroutine(TimerText());
            }
        }
        else {
            tmpPosition = gameObject.transform.position;
            SetOldPosition();
        }
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        scoretext.text = "Score: " + score;

        if (!isendlessmode) {
            if (score > hiscore) {
                hiscore = score;
                hiscoretext.text = "Hiscore: " + hiscore;
            }
        }
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        playerdata = playerdatacontainer.GetComponent<PlayerData>();

        oldPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);

        distanceFromCamera = Vector3.Distance(DragObj.position, cam.transform.position);
        r = DragObj.GetComponent<Rigidbody>();
        gameovercanvas.SetActive(false);
        endlessgameover.SetActive(false);
        endlessgamewon.SetActive(false);
        gamestarted = false;
        timerinseconds = 3;
        countdowntimer.text = timerinseconds.ToString();

        _segments = new List<Transform>();
        _segments.Add(this.transform);

        hiscore = playerdata.GetSnakeGameHiScore();

        scoretext.text = "Score: ";
        hiscoretext.text = "Hiscore: " + hiscore;

        isendlessmode = playerdata.IsEndlessMode();
        isChristmas = playerdata.GetChristmasTime();

        if (isChristmas)
        {
            regularbg.SetActive(false);
            christmasbg.SetActive(true);
            regularfood.SetActive(false);
            christmasfood.SetActive(true);
        }
        else
        {
            regularbg.SetActive(true);
            christmasbg.SetActive(false);
            regularfood.SetActive(true);
            christmasfood.SetActive(false);
        }

        if (!isendlessmode) {
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
        else {
            endlesscomplete = false;
            snakegamesplayed = playerdata.GetSnakeGamesPlayed();
            Debug.Log("Snake games played" + snakegamesplayed);
            hiscoretext.text = "";
            potentialscore = 10;

            //Difficulty scaling
            if (snakegamesplayed > 0) {
                potentialscore += 5 * snakegamesplayed;
            }
            
            wintext.text = "Score at least " + potentialscore + " to pass!";

        }


    }
    //this is supposed to track the positions of each segment in reverse order, spawning at the end of the sequence
    private void FixedUpdate()
    {
        if (isendlessmode) {
            if (!endlesscomplete) {
                if (gamestarted) {
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
                
            }
        }
        else {
            if (gamestarted) {
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
        }
        
    }

    //adds a segment
    private void Grow()
    {
        ethanDelay += ethanDelayDelta;
        if (!isChristmas) {
            littleGuys.Add(Instantiate(cloneObj));
        }
        else {
            littleGuys.Add(Instantiate(christmasCloneObj));
        }
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
        //GAME OVER
        if (other.gameObject.CompareTag("killbox"))
        {
            musicPlayer.Stop();
            Debug.Log("Hit Player");
            
            if (!isendlessmode) {
                gameovercanvas.SetActive(true);
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
            else {
                if (!endlesscomplete) {
                    endlessgameover.SetActive(true);
                    scoretext.text = "Score: " + score;

                    didWin = false;
                }
                else {
                    Debug.Log("You already won!");
                }
            }

            if (didWin)
            {
                PlaySound(win);
            }
            if(!didWin)
            {
                PlaySound(died);
            }
            gameObject.SetActive(false);
        }
        
        //snakefood == green box
        if (other.tag == "SnakeFood")
        {
            if (gamestarted) {
                Invoke("Grow", .4f);
                PlaySound(pickup);
                AddScore();
            } 
        }

    }
    public void AddScore()
    {
        score += 1;
        if (isendlessmode) {
            if (score >= potentialscore) {
                endlesscomplete = true;
                endlessgamewon.SetActive(true);
                didWin = true;
            }
        }
        
    }

    public void GoToDate()
    {
        playerdata.UpdatePlayerDateScore(didWin);
        if (hiscore > playerdata.GetSnakeGameHiScore()) {
            playerdata.NewSnakeGameHiScore(hiscore);
        }
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

    public void ContinueEndless() {
        if (didWin) {
            playerdata.IncreaseEndlessGamesPlayed();
            playerdata.IncreaseSnakeGamesPlayed();

            SceneManager.LoadScene("EndlessMode");
        }
        else {
            playerdata.DecreaseEndlessLives();
            
            SceneManager.LoadScene("EndlessMode");
        }
       
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("SnakeMinigame");
    }

    IEnumerator TimerText() {
        yield return new WaitForSeconds(0.75f);
        countdowntimer.enabled = false;
        gamestarted = true;
        StopCoroutine(TimerText());
    }
}
