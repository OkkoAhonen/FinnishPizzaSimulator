using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OvenTimer : MonoBehaviour
{
    public GameObject bar;
    public float maxValue = 10.0f;
    public float targetTime = 10.0f;
    public AudioClip sfx;
    private AudioSource ovenAudio;

    [SerializeField] private Bar timeBar;

    // Start is called before the first frame update
    private void Awake()
    {
        ovenAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime; // Oven timer: X sec - 1sec
        timeBar.UpdateTimer(targetTime, maxValue);

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    public void timerEnded()
    {
        ovenAudio.PlayOneShot(sfx, 1.0f); // Plays beep sound when pizza is ready
    }
}
