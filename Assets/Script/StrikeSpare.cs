using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StrikeSpare : MonoBehaviour
{
    public ScoreManager scoreTake;
    public Text strike;
    public Text spare;
    public bool show;
    public AudioSource source;
    public int rangeScan;
    public AudioClip[] clips;
    public int toPlay;
    public PaceController pace;
    // Start is called before the first frame update
    void Start()
    {
        strike.gameObject.SetActive(false);
        spare.gameObject.SetActive(false);
        show = false;
    }

    // Update is called once per frame
    public void strikeShow(){
        pace.gameObject.SetActive(false);
        show = true;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        toPlay = Random.Range(0,rangeScan - 3);
        source.PlayOneShot(clips[toPlay], 0.9F);
        source.Play();
        strike.gameObject.SetActive(true);
    }

    public void spareShow(){
        pace.gameObject.SetActive(false);
        show = true;
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        toPlay = Random.Range(3,rangeScan);
        source.PlayOneShot(clips[toPlay], 0.9F);
        source.Play();
        spare.gameObject.SetActive(true);
    }

    public void strikeNotShow(){
        show = false;
        source.Stop();
        strike.gameObject.SetActive(false);
    }

    public void spareNotShow(){
        show = false;
        source.Stop();
        spare.gameObject.SetActive(false);
    }

}
