using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] float _gameTime = 180.0f;
    [SerializeField] TMP_Text _timeDisplay;
    [SerializeField] EventObject TimeUp;
    //Serialized for debug purposes
    [SerializeField] float _timer;
    bool ready = false;


    public void ReadyClock()
    {
        if(_timeDisplay == null)
        {
            _timeDisplay = transform.GetChild(0).GetComponent<TMP_Text>();
        }

        _timer = _gameTime;
        _timeDisplay.text = convertTime(_timer);
        ready = true;
    }

    private string convertTime(float timeLeft)
    {
        //Get Seconds
        var ss = (timeLeft % 60).ToString("00");
        //Get Minutes
        var mm = (Mathf.Floor(timeLeft / 60) % 60).ToString("00");

        //Concat and return
        return mm + ":" + ss;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;

        _timer -= Time.deltaTime;
        _timeDisplay.text = convertTime(_timer);

        if(_timer <= 0)
        {
            _timeDisplay.text = convertTime(0);
            ready = false;
            TimeUp.TriggerEvent();
        }

    }
}
