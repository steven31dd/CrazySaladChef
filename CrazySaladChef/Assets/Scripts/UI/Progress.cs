using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] Slider progressSlider;

    //allows for initializing
    bool ready = false;

    //Initialize this script with StartTimer
    public void StartTimer(float timeLengthProgression)
    {
        progressSlider = GetComponent<Slider>();
        progressSlider.value = 0;
        progressSlider.minValue = Time.time;
        progressSlider.maxValue = Time.time + timeLengthProgression;
        ready = true;
    }

    //allow other scripts to check if progress is maxed/full
    public bool IsProgressComplete()
    {
        if (progressSlider.value >= progressSlider.maxValue) {
            ready = false;
            return true;
        }
           

        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;

        progressSlider.value = Time.time;
    }
}
