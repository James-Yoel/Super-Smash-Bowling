using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BowlingBall : MonoBehaviour
{
    public float minRange = -0.7f;
    public float maxRange = 0.7f;
    public float speed = 14f;
    public float horizontalSpeed = 35f;
    public float fillSpeed = 20f;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public Rigidbody ballBody;
    public bool thrown = false;
    public bool setPos = false;
    private float xAxis = 0.07f;
    private float xStart = 0;
    private float spdPlus = 0.5f;
    private float spdMax = 18f;
    private float spdMin = 14f;
    public bool dieBall = false;
    public PaceController paceController;
    public Image speedBar;
    public Image speedTemp;
    public AudioSource source;
    public bool roll = false;
    private bool paceStop = false;
    // Start is called before the first frame update
    void Start()
    {
        speed = 15f;
        ballBody = GetComponent<Rigidbody>();
        startPosition = gameObject.transform.localPosition;
        startRotation = gameObject.transform.localRotation;
        xStart = startPosition.x;
        speedBar.gameObject.SetActive(false);
        speedTemp.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(thrown == false && setPos == true){
            speed += Time.deltaTime * spdPlus * fillSpeed;
            if(speed >= spdMax){
                spdPlus = -0.5f;
                speed = spdMax;
            }
            else if(speed <= spdMin){
                spdPlus = 0.5f;
                speed = spdMin;
            }
            speedBar.fillAmount = (speed % spdMin)/ 4f;
        }
        if(thrown == false && setPos == true && Input.GetKeyDown(KeyCode.Space)){
            thrown = true;
            ballBody.isKinematic = false;
            ballBody.velocity = new Vector3(0, 0, speed);
            transform.rotation = Quaternion.LookRotation(ballBody.velocity);
            speedBar.gameObject.SetActive(false);
            speedTemp.gameObject.SetActive(false);
        }
        if(thrown == false && setPos == false){
            xStart += Time.deltaTime * xAxis * horizontalSpeed;
            if(xStart >=  maxRange){
                xAxis = -0.07f;
                xStart = maxRange;
            }
            else if(xStart <= minRange){
                xAxis = 0.07f;
                xStart = minRange;
            }
            transform.position = new Vector3(xStart, startPosition.y, startPosition.z);
        }
        if(thrown == false && setPos == false && Input.GetKeyDown(KeyCode.Space)){
            setPos = true;
            speedBar.gameObject.SetActive(true);
            speedTemp.gameObject.SetActive(true);
        }
        if(thrown == true){
            if(paceStop == false){
                paceController.activateObj();
                paceStop = true;
            }
            if(roll == false){
                source.Play();
                roll = true;
            }
            Invoke("killBall", 7);
        }
        if(thrown == true && ballBody.IsSleeping() == true){
            source.Stop();
        }
    }

    public void killBall(){
        source.Stop();
        ballBody.isKinematic = true;
        ballBody.velocity = Vector3.zero;
        dieBall = true;
    }

    public void ResetBall(){
        source.Stop();
        transform.localPosition = startPosition;
        transform.localRotation = startRotation;
        setPos = false;
        thrown = false;
        speed = 15f;
        ballBody.velocity = Vector3.zero;
        ballBody.isKinematic = true;
        xStart = startPosition.x;
        CancelInvoke();
        dieBall = false;
        roll = false;
        paceStop = false;
    }
}
