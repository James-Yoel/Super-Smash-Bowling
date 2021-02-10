using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    [SerializeField]
    public Image ProgressBar;
    public Image overlay;
    private int sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        sceneToLoad = SceneLoader.scenePick;
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation(){
        yield return new WaitForSeconds(1.5f);
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(sceneToLoad);
        gameLevel.allowSceneActivation = false;
        while(gameLevel.progress < 1){
            ProgressBar.fillAmount = gameLevel.progress;
            overlay.fillAmount = gameLevel.progress;
            if(gameLevel.progress == 0.9f){
                yield return new WaitForSeconds(2.0f);
                gameLevel.allowSceneActivation = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
