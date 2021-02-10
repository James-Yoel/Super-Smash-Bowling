using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinMove : MonoBehaviour
{
    public GameObject findBall;
    public BowlingBall ball;
    public float xStart;
    public Vector3 position;
    private float xAxis = 0.046f;
    private float horizontalSpeed = 15f;
    private float maxRange = 0.46f;
    private float minRange = -0.46f;
    public GameObject pins;
    public PinReset pinReset;
    // Start is called before the first frame update
    void Start()
    {
        findBall = GameObject.FindGameObjectWithTag("Ball");
        ball = findBall.GetComponent<BowlingBall>();
        position = gameObject.transform.position;
        xStart = position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex >= 4){
            if(ball.thrown == false){
                xStart += Time.deltaTime * xAxis * horizontalSpeed;
                if(xStart >=  maxRange){
                    xAxis = -0.07f;
                    xStart = maxRange;
                }
                else if(xStart <= minRange){
                    xAxis = 0.07f;
                    xStart = minRange;
                }
                gameObject.transform.position = new Vector3(xStart, position.y, position.z);
            }
            else{
                if(gameObject.transform.childCount > 1){
                    pins = gameObject.transform.GetChild(0).gameObject;
                    pinReset = pins.GetComponent<PinReset>();
                    pinReset.pinBody.isKinematic = false;
                }
            }
        }
    }
}
