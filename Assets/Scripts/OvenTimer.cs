using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenTimer : MonoBehaviour
{
    public float maxValue = 10.0f;
    public float targetTime = 10.0f;
    public AudioClip beep;
    public AudioClip ovenSound;
    private AudioSource ovenAudio;

    [SerializeField] private Bar timeBar;

    // Start is called before the first frame update
    private void Awake()
    {
        ovenAudio = GetComponent<AudioSource>();

        oven();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime; // Oven timer: X sec - 1sec
        timeBar.UpdateTimer(targetTime, maxValue);

        /*if (targetTime <= 0.0f)
        {
            ovenAudio.Stop();
            //timerEnded();
        }*/
    }

    public void oven()
    {
        ovenAudio.PlayOneShot(ovenSound, 5.0f);

    }

    /*public void timerEnded()
    {
        ovenAudio.PlayOneShot(beep); // Plays beep sound when pizza is ready
    }*/
}
