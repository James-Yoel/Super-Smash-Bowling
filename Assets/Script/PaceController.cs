using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaceController : MonoBehaviour
{
    public bool normal;
    public bool fast;
    public bool slow;
    public Text desc; 

    // Start is called before the first frame update
    void Start()
    {
        normal = true;
        fast = false;
        slow = false;
        desc.text = "Normal";
        gameObject.SetActive(false); 
    }

    // Update is called once per frame
    public void paceClick(){
        if(normal == true){
            Time.timeScale = 1.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            fast = true;
            normal = false;
            desc.text = "Fast";
        }
        else if(fast == true){
            Time.timeScale = 0.5f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            slow = true;
            fast = false;
            desc.text = "Slow";
        }
        else if(slow == true){
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            normal = true;
            slow = false;
            desc.text = "Normal";
        }
    }

    public void activateObj(){
        gameObject.SetActive(true);
    }

    public void resetPace(){
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        normal = true;
        fast = false;
        slow = false;
        desc.text = "Normal";
        gameObject.SetActive(false);
    }
}