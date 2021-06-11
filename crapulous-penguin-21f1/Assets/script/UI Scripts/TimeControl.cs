using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public float countDownTime;

    [SerializeField]private Text timeText;
    // Start is called before the first frame update
    void Awake()
    {
        timeText = this.GetComponent<Text>();
        timeText.text = $"{(int)(countDownTime / 60)}:{countDownTime%60}";
    }

    // Update is called once per frame
    void Update()
    {
        countDownTime -= Time.deltaTime;
        int min = (int)countDownTime / 60;
        int sec = (int)countDownTime % 60;
        timeText.text = min + ":" + (sec < 10 ? "0" : "") + sec;
        if (countDownTime <= 0f)
        {
            timeText.text = "0:00";
        }
    }
}
