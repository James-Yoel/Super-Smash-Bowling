using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearShow : MonoBehaviour
{
    public ChallengeManager challenge;
    public Text clear;
    public bool show;
    public AudioSource source;
    public AudioClip[] clips;
     public PaceController pace;
    // Start is called before the first frame update
    void Start()
    {
        clear.gameObject.SetActive(false);
        show = false;
    }

    // Update is called once per frame
    public void showClear(){
        pace.resetPace();
        show = true;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        source.PlayOneShot(clips[challenge.life - 1], 0.9F);
        source.Play();
        clear.gameObject.SetActive(true);
    }

    public void stopClear(){
        show = false;
        source.Stop();
        clear.gameObject.SetActive(false);
    }
}
