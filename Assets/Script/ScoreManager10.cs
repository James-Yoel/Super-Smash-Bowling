using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager10 : MonoBehaviour
{
    public int frame = 1;
    public int frameBall = 0;
    public int ballScore = 0;
    public int frameBefore = 0;
    public int scoreTotal = 0;
    public int checkStrike = 0;
    private bool reset10 = false;
    private bool wait = false;
    private bool noCount = false;
    public PinReset[] pin;
    public BowlingBall ball;
    public ScoreShow10 scoreShow;
    public FrameBall10 frameShow;
    public StrikeSpare strikeSpare;
    public PaceController paceController;
    public ResultMenu10 resultMenu;
    public AudioSource playTheme;
    public AudioSource resultSource;
    public AudioClip[] resultClips;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int i;
        if(frameShow.show == true){
            frameShow.showFrameBall();
        }
        if(ball.thrown == true && ball.dieBall == true){
            if(wait == false){
                wait = true;
                for(i = 0; i < pin.Length; i++){
                    pin[i].CheckPosition();
                    if(pin[i].afterPosition.y < -0.007f){
                        ballScore += 1;
                        pin[i].gameObject.SetActive(false);
                    }
                }
            }
            if(frame < 10){
                if(noCount == false){
                    noCount = true;
                    Debug.Log(ballScore);
                    Debug.Log(frameBall);
                    if(ballScore >= 10 && frameBall == 0){
                        frameBall = 2;
                        scoreTotal += 30;
                        checkStrike = 1;
                        strikeSpare.strikeShow();
                        Debug.Log("STRIKE");
                        StartCoroutine(waitTwoS());
                    }
                    else if(ballScore + frameBefore >= 10 && frameBall == 1){
                        frameBall = 2;
                        scoreTotal += 10;
                        checkStrike = 2;
                        strikeSpare.spareShow();
                        Debug.Log("SPARE");
                        StartCoroutine(waitTwoS());
                    }
                    else{
                        frameBall += 1;
                        scoreTotal += ballScore;
                    }
                }
                if(strikeSpare.show == false){
                    Debug.Log(scoreTotal);
                    ball.ResetBall();
                    paceController.resetPace();
                    if(frameBall != 2){
                        scoreShow.InputPin();
                        for(i = 0; i < pin.Length; i++){
                            pin[i].ResetPin();
                        }
                        frameBefore = ballScore;
                        ballScore = 0;
                        frameShow.show = true;
                        noCount = false;
                        wait = false;
                    }
                    else{
                        scoreShow.InputPin();
                        scoreShow.InputScore();
                        ballScore = 0;
                        frameBall = 0;
                        frameBefore = 0;
                        frame += 1;
                        checkStrike = 0;
                        for(i = 0; i < pin.Length; i++){
                            pin[i].ResetPin();
                            pin[i].gameObject.SetActive(true);
                        }
                        frameShow.show = true;
                        noCount = false;
                        wait = false;
                    }
                }
            }
            else{
                if(noCount == false){
                    noCount = true;
                    if(ballScore >= 10 && frameBefore == 0){
                        scoreTotal += 30;
                        checkStrike = 1;
                        reset10 = true;
                        strikeSpare.strikeShow();
                        StartCoroutine(waitTwoS());
                    }
                    else if(ballScore + frameBefore >= 10 && frameBefore != 0){
                        scoreTotal += 10;
                        checkStrike = 2;
                        reset10 = true;
                        strikeSpare.spareShow();
                        StartCoroutine(waitTwoS());
                    }
                    else{
                        scoreTotal += ballScore;
                    }
                }
                if(strikeSpare.show == false){
                    frameBall += 1;
                    Debug.Log(frameBall);
                    Debug.Log(scoreTotal);
                    ball.ResetBall();
                    paceController.resetPace();
                    if(frameBall < 3){
                        scoreShow.InputPin();
                        if(reset10 == true){
                            checkStrike = 0;
                            ballScore = 0;
                            frameBefore = 0;
                            for(i = 0; i < pin.Length; i++){
                                pin[i].ResetPin();
                                pin[i].gameObject.SetActive(true);
                            }
                            reset10 = false;
                            frameShow.show = true;
                            noCount = false;
                            wait = false;
                        }
                        else{
                            for(i = 0; i < pin.Length; i++){
                                pin[i].ResetPin();
                            }
                            frameBefore = ballScore;
                            ballScore = 0;
                            frameShow.show = true;
                            noCount = false;
                            wait = false;
                        }
                    }
                    else if(frameBall == 3){
                        scoreShow.InputPin();
                        scoreShow.InputScore();
                        Debug.Log("Finish");
                        resultMenu.resultShow();
                        if(scoreTotal >= 180){
                            resultSource.PlayOneShot(resultClips[0], 0.9F);
                            resultSource.Play();
                        }
                        else{
                            resultSource.PlayOneShot(resultClips[1], 0.9F);
                            resultSource.Play();
                        }
                        playTheme.volume = 0.15f;
                    }
                }
            }
        }
    }

    IEnumerator waitTwoS(){
        yield return new WaitForSeconds(2.5f);
        strikeSpare.strikeNotShow();
        strikeSpare.spareNotShow();
    }
}