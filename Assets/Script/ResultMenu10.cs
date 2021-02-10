using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultMenu10 : MonoBehaviour
{
    public Image blur;
    public SceneLoader sceneLoader;
    public Text totalScore;
    public ScoreManager10 scoreTake;
    public PauseMenu pause;
    public Text dialog;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void resultShow()
    {
        if(scoreTake.scoreTotal == 0){
            dialog.text = "You're doing this on purpose aren't you ?";
        }
        else if(scoreTake.scoreTotal >= 1 && scoreTake.scoreTotal < 90){
            dialog.text = "Better luck next time !";
        }
        else if(scoreTake.scoreTotal >= 90 && scoreTake.scoreTotal < 180){
            dialog.text = "Keep trying and you can do it !";
        }
        else if(scoreTake.scoreTotal >= 180 && scoreTake.scoreTotal < 270){
            dialog.text = "Great Job, Keep up the good play !";
        }
        else if(scoreTake.scoreTotal >= 270 && scoreTake.scoreTotal < 360){
            dialog.text = "Amazing, You smash the game !";
        }
        else if(scoreTake.scoreTotal == 360){
            dialog.text = "Perfect Score, You are the Super Smash Bowler !";
        }
        pause.finish = true;
        totalScore.text = scoreTake.scoreTotal.ToString();
        blur.gameObject.SetActive(true);
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void exitGame(){
        SceneLoader.scenePick = 0;
        StartCoroutine(LoadScene());
    }

    public void retryGame(){
        SceneLoader.scenePick = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene(){
        Time.timeScale = 1.0f;
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }
}
