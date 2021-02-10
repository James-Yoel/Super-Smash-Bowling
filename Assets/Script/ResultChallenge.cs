using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultChallenge : MonoBehaviour
{
    public Image blur;
    public SceneLoader sceneLoader;
    public ChallengeManager challenge;
    public PauseMenu pause;
    public Text dialogSuccess;
    public Text dialogFailed;
    public string[] failureDialog = {"Never Give Up !", "So Close !", "At least you tried."};
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void resultShow(){
        if(challenge.life == 3){
            dialogSuccess.text = "What a Perfect Play !";
        }
        else if(challenge.life >= 1){
            dialogSuccess.text = "Well Done you beat the challenge !";
        }
        else if(challenge.life == 0){
            dialogFailed.text = failureDialog[Random.Range(0, 2)];
        }
        pause.finish = true;
        blur.gameObject.SetActive(true);
        gameObject.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void nextGame(){
        SceneLoader.scenePick = SceneManager.GetActiveScene().buildIndex + 1;
        StartCoroutine(LoadScene());
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
