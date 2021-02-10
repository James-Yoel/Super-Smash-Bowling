using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinReset : MonoBehaviour
{
    public Vector3 position;
    public Vector3 afterPosition;
    public Quaternion rotation;
    public BowlingBall ball;
    public AudioSource source;
    public Rigidbody pinBody;

    void Start(){
        if(SceneManager.GetActiveScene().buildIndex > 4){
            pinBody.isKinematic = true;
        }
    }
    void OnEnable(){
        position = gameObject.transform.localPosition;
        rotation = gameObject.transform.localRotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    void Update(){
        
    }

    public void CheckPosition(){
        afterPosition = gameObject.transform.localPosition;
    }

    public void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag.Equals("Ball")){
            source.Play();
        }
    }

    public void ResetPin(){
        gameObject.transform.localPosition = position;
        gameObject.transform.localRotation = rotation;
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if(SceneManager.GetActiveScene().buildIndex > 4){
            pinBody.isKinematic = true;
        }
    }
    
}
