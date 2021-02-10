using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditOption : MonoBehaviour
{
    public Animator creditAnim;
    public GameObject panel;
    public GameObject backgroundAnim;
    public Image gameLogo;
    public GameObject howTo;
    public GameObject mainMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(creditAnim.GetBool("IsEnd") == true){
            gameObject.SetActive(false);
            panel.SetActive(false);
            backgroundAnim.SetActive(true);
            gameLogo.gameObject.SetActive(true);
            howTo.gameObject.SetActive(true);
            mainMenu.SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            isEnd();
        }
    }

    public void isEnd(){
        creditAnim.SetBool("IsEnd", true);
    }
}
