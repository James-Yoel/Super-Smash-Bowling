using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public void playFrame5(){
        SceneLoader.scenePick = 2;
        StartCoroutine(LoadScene());
    }

    public void playFrame10(){
        SceneLoader.scenePick = 3;
        StartCoroutine(LoadScene());
    }

    public void playChallenge1(){
        SceneLoader.scenePick = 4;
        StartCoroutine(LoadScene());
    }

    public void playChallenge2(){
        SceneLoader.scenePick = 5;
        StartCoroutine(LoadScene());
    }

    public void playChallenge3(){
        SceneLoader.scenePick = 6;
        StartCoroutine(LoadScene());
    }

    public void quitGame(){
        Application.Quit();
    }

    IEnumerator LoadScene(){
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(1);
    }
}
