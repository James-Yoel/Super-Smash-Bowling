using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreShow : MonoBehaviour
{
    public ScoreManager scoreTake;
    public Text[] pin;
    public Text[] score;
    private int i = 0;
    private int j = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void InputPin()
    {
        if(scoreTake.ballScore == 10 && scoreTake.checkStrike == 1){
            pin[i].text = "X";
            if(scoreTake.frame != 5){
                i += 1;
            }
        }
        else if(scoreTake.checkStrike == 2){
            pin[i].text = "/";
        }
        else{
            pin[i].text = scoreTake.ballScore.ToString();
        }
        i += 1;
    }

    public void InputScore(){
        score[j].text = scoreTake.scoreTotal.ToString();
        j += 1;
    }
}
