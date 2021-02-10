using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameBallChallenge : MonoBehaviour
{
    public Text ball;
    public bool show;
    public ChallengeManager challenge;
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        show = true;
        canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
    }

    public void showFrameBall(){
        gameObject.SetActive(true);
        StartCoroutine(activatePanel());
        ball.text = "Ball " + (challenge.frameBall).ToString();
        StartCoroutine(deactivatePanel());
    }

    IEnumerator activatePanel(){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime / 2;
            yield return null;
        }
        yield return null;
    }

    IEnumerator deactivatePanel(){
        yield return new WaitForSeconds(2f);
        while(canvasGroup.alpha > 0){
            canvasGroup.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        show = false;
        gameObject.SetActive(false);
    }
}
