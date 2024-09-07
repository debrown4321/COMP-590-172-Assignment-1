using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    TimeSpan timeLeft;
    TimeSpan timeTook;
    public TextMeshProUGUI timer;
    public AllDone allDone;
    bool finished;
    bool start;

    void Start()
    {
        timeLeft = TimeSpan.FromSeconds(181f);
        timeTook = TimeSpan.Zero;
        finished = false;
        start = false;
    }

    void Update()
    {
        if (start)
        {
            if (allDone.CheckDone())
            {
                timer.text = "You time is:\n" + timeTook.ToString(@"m\:ss");
                finished = true;
            }
            else
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(Time.deltaTime));
                timeTook = timeTook.Add(TimeSpan.FromSeconds(Time.deltaTime));
                timer.text = timeLeft.ToString(@"m\:ss");
            }
            if (finished == true && allDone.CheckDone() == false)
            {
                timeLeft = TimeSpan.FromSeconds(181f);
                timeTook = TimeSpan.Zero;
                finished = false;
            }
        }
    }

    public void StartTimer()
    {
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        timer.text = "3";

        yield return new WaitForSeconds(.5f);

        timer.text = "2";

        yield return new WaitForSeconds(.5f);

        timer.text = "1";

        yield return new WaitForSeconds(.5f);

        timer.text = "Go!";

        yield return new WaitForSeconds(.5f);

        start = true;
    }
}
