using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightManager : MonoBehaviour
{
    public Light sun;
    public Light[] point;
    public GameObject reflect;
    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 6){
            int i;
            for(i = 0; i < point.Length; i++){
                point[i].gameObject.SetActive(true);
            }
            sun.intensity = 0;
            reflect.SetActive(false);
        }
    }

    // Update is called once per frame
    public void offLight()
    {
        int i;
        for(i = 0; i < point.Length; i++){
            point[i].gameObject.SetActive(false);
        }
        sun.intensity = 1;
        reflect.SetActive(true);
    }

    public void onLight(){
        int i;
        for(i = 0; i < point.Length; i++){
            point[i].gameObject.SetActive(true);
        }
        sun.intensity = 0;
        reflect.SetActive(false);
    }
}
