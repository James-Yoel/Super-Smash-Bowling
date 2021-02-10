using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool pauseGame = false;
    public Image blur;
    public GameObject pauseUI;
    public PaceController pace;
    public SceneLoader sceneLoader;
    public bool finish = false;
    public AudioSource playTheme;
    public AudioSource button;
    public AudioSource click;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finish == false){
            if(Input.GetKeyDown(KeyCode.Escape)){
                if(pauseGame == true){
                    button.Play();
                    resumeGame();
                }
                else{
                    click.Play();
                    pauseMenu();
                }
            }
        }
    }

    public void resumeGame(){
        blur.gameObject.SetActive(false);
        pauseUI.SetActive(false);
        if(pace.normal == true){
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else if(pace.fast == true){
            Time.timeScale = 1.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else if(pace.slow == true){
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        else{
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        playTheme.volume = 0.4f;
        pauseGame = false;
    }

    public void pauseMenu(){
        if(finish == false){
            blur.gameObject.SetActive(true);
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
            playTheme.volume = 0.15f;
            pauseGame = true;
        }
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
