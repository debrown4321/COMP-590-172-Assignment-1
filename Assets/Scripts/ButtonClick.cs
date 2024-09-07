using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class ButtonClick : MonoBehaviour
{

    public BallPrefab ballPrefab;
    private float cooldown;
    public AllDone allDone;
    public TextMeshProUGUI pressMessage;
    public TextMeshProUGUI startMessage;
    public WhiteHit white;
    public Timer timer;
    bool canShoot;
    bool timerStart;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = false;
        timerStart = false;
        startMessage.text = "Welcome to Archery!";
        pressMessage.text = "Tap the screen to play!";
    }

    // Update is called once per frame
    void Update()
    {
        if (canShoot)
        {
            if (allDone.CheckDone())
            {
                pressMessage.text = "Tap the screen to play again!";

                StartCoroutine(Reset());

                canShoot = false;
            }
            else
            {
                if (cooldown > 0)
                {
                    cooldown -= Time.deltaTime;
                }

                if (Touchscreen.current.press.isPressed && cooldown <= 0)
                {
                    cooldown = 0.5f;  // this is the interval between firing.
                    BallPrefab ball = Instantiate<BallPrefab>(ballPrefab);
                    ball.transform.localPosition = transform.position;
                    ball.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward *
                        UnityEngine.Random.Range(1250, 1500));
                }
            }
        } else
        {
            StartCoroutine(StartTimer());
        }


    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(1f);

        if (Touchscreen.current.press.isPressed)
        {
            white.Reset();
            pressMessage.text = "";
        }

        yield return new WaitForSeconds(.5f);

        canShoot = true;
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(.5f);

        if (Touchscreen.current.press.isPressed && timerStart == false)
        {
            timer.StartTimer();
            pressMessage.text = "";
            timerStart = true;
        }

        yield return new WaitForSeconds(3f);

        canShoot = true;
    }
}
