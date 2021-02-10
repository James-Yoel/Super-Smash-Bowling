using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    public GameObject[] pinPrefab;
    public GameObject[] checkPin;
    public PinReset reset;
    public int down = 0;
    public bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        int i;
        float x = 0f, y = 0.265f ,z = 18.47f;
        for(i = 0; i < pinPrefab.Length; i++){
            GameObject pin = Instantiate<GameObject>(pinPrefab[i]);
            pin.transform.localPosition = new Vector3(x, y, z);
            if(i == 0){
                x = -0.15f;
                z = 18.72f;
            }
            else if(i == 1){
                x = 0.15f;
            }
            else if(i == 2){
                x = -0.3f;
                z = 18.97f;
            }
            else if(i == 3){
                x = 0.3f;
            }
        }
    }

    //Update is called once per frame
    public void CheckPinClone()
    {
        int i;
        checkPin = GameObject.FindGameObjectsWithTag("pin");
        for(i = 0; i < checkPin.Length; i++){
            if(checkPin[i].transform.localPosition.y < -0.007f){
                Destroy(checkPin[i]);
                down += 1;
            }
        }
        if(down == 5){
            finish = true;
        }
    }

    public void resetPin(){
        int i;
        checkPin = GameObject.FindGameObjectsWithTag("pin");
        for(i = 0; i < checkPin.Length; i++){
            reset = checkPin[i].GetComponent<PinReset>();
            reset.ResetPin();
        }
    }
}
