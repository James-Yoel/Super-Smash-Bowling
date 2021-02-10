using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlurAnimation : MonoBehaviour
{
    public Image blur;
    public float speed = 0.01f;
    public float size;
    private Material rend;
    // Start is called before the first frame update
    void Start()
    {
        size = 1.2f;
        rend = blur.material;
    }

    // Update is called once per frame
    void Update()
    {
        size = rend.GetFloat("_Size");
        size += speed;
        if(size >= 4.5f){
            size = 4.5f;
            speed = -0.01f;
        }
        else if(size <= 0.5f){
            size = 0.5f;
            speed = 0.01f;
        }
        rend.SetFloat("_Size", size);
    }
}
