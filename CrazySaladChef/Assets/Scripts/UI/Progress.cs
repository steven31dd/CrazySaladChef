using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{
    [SerializeField] Slider progressSlider;
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    Camera cam;

    //allows for initializing
    bool ready = false;

    private void Start()
    {
        cam = Camera.main;
    }

    //Initialize this script with StartTimer
    public void StartTimer(float timeLengthProgression, Transform newtarget)
    {
        target = newtarget;

        progressSlider = GetComponent<Slider>();
        progressSlider.value = 0;
        progressSlider.minValue = Time.time;
        progressSlider.maxValue = Time.time + timeLengthProgression;
        ready = true;
    }

    //Initialize this script with StartTimer with an offset
    public void StartTimerOffset(float timeLengthProgression, Transform newtarget, Vector3 newOffset)
    {
        target = newtarget;
        offset = newOffset;
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

        Vector3 pos = cam.WorldToScreenPoint(target.position + offset);

        if (transform.position != pos)
            transform.position = pos;

        progressSlider.value = Time.time;
    }
}
