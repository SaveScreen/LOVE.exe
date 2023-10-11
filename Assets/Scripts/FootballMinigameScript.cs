using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FootballMinigameScript : MonoBehaviour
{
    public GameObject powermeter;
    public GameObject powertriangle;
    private float trianglemaxposition;
    private float triangleminposition;
    //private float accuracyminposition;
    //private float accuracymaxposition;
    private bool isgoingup;
    private bool enableaccuracy;
    public GameObject accuracymeter;
    [SerializeField] private float timer;
    private int timerinseconds;
    public TextMeshProUGUI countdowntimer;
    private bool gamestarted;
    public float powermeterspeed;
    public InputActionAsset inputs;
    
    // Start is called before the first frame update
    void Start()
    {
        gamestarted = false;
        countdowntimer.text = timerinseconds.ToString();
        powermeter.SetActive(false);
        accuracymeter.SetActive(false);

        trianglemaxposition = 1.4f;
        triangleminposition = -1.4f;
        isgoingup = true;
        enableaccuracy = false;
    }

    void OnEnable() {
        inputs.Enable();
    }

    void OnDisable() {
        inputs.Disable();
    }

    // Update is called once per frame
    void Update()
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

            if (!enableaccuracy)
            {
                powermeter.SetActive(true);
                if (isgoingup)
                {
                    if (powertriangle.transform.localPosition.y < trianglemaxposition)
                    {
                        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x, Mathf.MoveTowards(powertriangle.transform.localPosition.y, trianglemaxposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        isgoingup = false;
                    }
                }
                else
                {
                    if (powertriangle.transform.localPosition.y > triangleminposition)
                    {
                        powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x, Mathf.MoveTowards(powertriangle.transform.localPosition.y, triangleminposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        isgoingup = true;
                        enableaccuracy = true;
                    }
                }

            }
            else
            {
                powermeter.SetActive(false);
                accuracymeter.SetActive(true);
                if (isgoingup)
                {
                    if (accuracymeter.transform.position.x < trianglemaxposition)
                    {
                        accuracymeter.transform.position = new Vector2(accuracymeter.transform.position.x, Mathf.MoveTowards(accuracymeter.transform.position.y, trianglemaxposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        isgoingup = false;
                    }
                }
                else
                {
                    if (accuracymeter.transform.position.x > triangleminposition)
                    {
                        accuracymeter.transform.position = new Vector2(accuracymeter.transform.position.x, Mathf.MoveTowards(accuracymeter.transform.position.y, triangleminposition, powermeterspeed * Time.deltaTime));
                    }
                    else
                    {
                        isgoingup = false;
                    }
                }
            }

        }
        
    }

    IEnumerator TimerText() {
        yield return new WaitForSeconds(0.75f);
        countdowntimer.enabled = false;
        gamestarted = true;
        StopCoroutine(TimerText());
    }
}
