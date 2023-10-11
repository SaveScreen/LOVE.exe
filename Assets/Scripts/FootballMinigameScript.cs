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
    private bool isgoingup;
    public GameObject accuracymeter;
    [SerializeField] private float timer; //set to 3 seconds
    private int timerinseconds;
    public TextMeshProUGUI countdowntimer;
    private bool gamestarted;
    public float powermeterspeed;
    public InputActionAsset inputs;
    private float interpolation = 0;

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
                }
            }
            
            
            /*
            if (isgoingup) {
                if (interpolation < 1.0f) {
                    powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x,Mathf.Lerp(powertriangle.transform.localPosition.y,trianglemaxposition,interpolation));
                    interpolation += powermeterspeed ;
                    //Debug.Log(powertriangle.transform.localPosition.y.ToString());
                    Debug.Log(interpolation);
                }
                else {
                    isgoingup = false;
                }
                
            }
            else {
                if (interpolation > 0) {
                    powertriangle.transform.localPosition = new Vector2(powertriangle.transform.localPosition.x,Mathf.Lerp(powertriangle.transform.localPosition.y,triangleminposition,interpolation));
                    interpolation -= powermeterspeed * Time.deltaTime;
                    Debug.Log(interpolation);
                } else {
                    isgoingup = true;
                }
            }
            */   

        }
        
    }

    IEnumerator TimerText() {
        yield return new WaitForSeconds(0.75f);
        countdowntimer.enabled = false;
        gamestarted = true;
        StopCoroutine(TimerText());
    }
}
