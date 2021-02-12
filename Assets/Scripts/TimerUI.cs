using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public float numSeconds = 300f;
    public float timeRemaining;
    public Image bar;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = numSeconds;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining = timeRemaining - Time.deltaTime;
            bar.transform.localScale = new Vector3(timeRemaining / numSeconds, 1f, 1f);
        }
    }
}
