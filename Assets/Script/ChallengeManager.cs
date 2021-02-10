using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChallengeManager : MonoBehaviour
{
    public int frameBall = 1;
    public int life = 3;
    public int i = 0;
    public BowlingBall ball;
    public PinSpawner pin;
    public PinSpawner2 pin2;
    public ResultChallenge resultSuccess;
    public ResultChallenge resultFailed;
    public PaceController pace;
    public AudioSource playTheme;
    public AudioSource resultAudio;
    public AudioClip[] resultClips;
    public Image[] lifeTexture;
    public FrameBallChallenge frameShow;
    public ClearShow clear;
    public bool show = true;
    private bool clearCheck = false;
    private bool runAudio = false;
    public LightManager lightManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(SceneManager.GetActiveScene().buildIndex == 4){
            if(frameShow.show == true){
                frameShow.showFrameBall();
            }
            if(ball.thrown == true && ball.dieBall == true){
                pin.CheckPinClone();
                pace.resetPace();
                if(pin.finish == true){
                    show = false;
                    if(clearCheck == false){
                        if(runAudio == false){
                            clear.showClear();
                            StartCoroutine(waitTwoS());
                            runAudio = true;
                        }
                    }
                    else{
                        resultSuccess.resultShow();
                        resultAudio.PlayOneShot(resultClips[0], 0.9F);
                        resultAudio.Play();
                        playTheme.volume = 0.15f;
                    }
                }
                else{
                    clearCheck = true;
                    frameBall += 1;
                    life -= 1;
                    lifeTexture[i].gameObject.SetActive(false);
                    i += 1;
                }
                if(clearCheck == true){
                    pin.resetPin();
                    ball.ResetBall();
                    clearCheck = false;
                }
                if(frameBall == 4 && life == 0){
                    show = false;
                    resultFailed.resultShow();
                    resultAudio.PlayOneShot(resultClips[1], 0.9f);
                    resultAudio.Play();
                    playTheme.volume = 0.15f;
                }
                if(show == true){
                    frameShow.show = true;
                }
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 5){
            if(frameShow.show == true){
                frameShow.showFrameBall();
            }
            if(ball.thrown == true && ball.dieBall == true){
                pin2.CheckPinClone();
                pace.resetPace();
                if(pin2.finish == true){
                    show = false;
                    if(clearCheck == false){
                        if(runAudio == false){
                            clear.showClear();
                            StartCoroutine(waitTwoS());
                            runAudio = true;
                        }
                    }
                    else{
                        resultSuccess.resultShow();
                        resultAudio.PlayOneShot(resultClips[0], 0.9F);
                        resultAudio.Play();
                        playTheme.volume = 0.15f;
                    }
                }
                else{
                    clearCheck = true;
                    frameBall += 1;
                    life -= 1;
                    lifeTexture[i].gameObject.SetActive(false);
                    i += 1;
                }
                if(clearCheck == true){
                    pin2.resetPin();
                    ball.ResetBall();
                    clearCheck = false;
                }
                if(frameBall == 4 && life == 0){
                    show = false;
                    resultFailed.resultShow();
                    resultAudio.PlayOneShot(resultClips[1], 0.9f);
                    resultAudio.Play();
                    playTheme.volume = 0.15f;
                }
                if(show == true){
                    frameShow.show = true;
                }
            }
        }
        else if(SceneManager.GetActiveScene().buildIndex == 6){
            if(frameShow.show == true){
                frameShow.showFrameBall();
            }
            if(ball.thrown == true){
                lightManager.offLight();
            }
            if(ball.thrown == true && ball.dieBall == true){
                pin2.CheckPinClone();
                pace.resetPace();
                if(pin2.finish == true){
                    show = false;
                    if(clearCheck == false){
                        if(runAudio == false){
                            clear.showClear();
                            StartCoroutine(waitTwoS());
                            runAudio = true;
                        }
                    }
                    else{
                        clearCheck = false;
                        lightManager.offLight();
                        resultSuccess.resultShow();
                        resultAudio.PlayOneShot(resultClips[0], 0.9F);
                        resultAudio.Play();
                        playTheme.volume = 0.15f;
                    }
                }
                else{
                    clearCheck = true;
                    frameBall += 1;
                    life -= 1;
                    lifeTexture[i].gameObject.SetActive(false);
                    i += 1;
                }
                if(clearCheck == true){
                    lightManager.onLight();
                    pin2.resetPin();
                    ball.ResetBall();
                    clearCheck = false;
                }
                if(frameBall == 4 && life == 0){
                    lightManager.offLight();
                    show = false;
                    resultFailed.resultShow();
                    resultAudio.PlayOneShot(resultClips[1], 0.9f);
                    resultAudio.Play();
                    playTheme.volume = 0.15f;
                }
                if(show == true){
                    frameShow.show = true;
                }
            }
        }
    }

    IEnumerator waitTwoS(){
        yield return new WaitForSeconds(2.5f);
        clear.stopClear();
        clearCheck = true;
    }
}
