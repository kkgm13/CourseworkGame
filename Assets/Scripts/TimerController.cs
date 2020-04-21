using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    // Update is called once per frame
    void Update()
    {
        float time = Time.timeSinceLevelLoad;
        // int hour = (int) ; // Hour???
        int minute = (int) ((time / 60) % 60);
        int seconds = (int) (time % 60);

        timeText.text = string.Format("{0:D1}:{1:D2}",minute,seconds);
    }
}
