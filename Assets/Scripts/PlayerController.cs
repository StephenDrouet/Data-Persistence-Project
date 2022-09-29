using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject lineObject;
    private LineRenderer lineRenderer;
    public Rigidbody ballRb;
    private SpawnManager spawnManager;


    private float horizontalInput;
    private float xBound = 44.5f;
    public bool isOnPlayer = true;

    private float xPos = 0;
    private float yPos = 0;
    private Vector3 initDirection;
    private float magnitudeline = 10;
    private float correction = 5;
    private float initForce = 56.25f;

    public float speed = 50.0f;
    public float forceBall = 7.5f;
    public float angleMultiply = 10f;
    // Start is called before the first frame update
    void Start()
    {        
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        lineRenderer = lineObject.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, new Vector3(0, 2, 0));
        lineObject.SetActive(true);
        xPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManager.isGaming)
        {
            if (isOnPlayer)
            {
                ControlLine();
            }
            else
            {
                HorizontalMove();
            }
        }
        else
        {
            restartScene();
        }
    }

    void restartScene()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(1);
        }
    }

    void ControlLine()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        xPos += horizontalInput * Time.deltaTime * speed / 3;

        if (xPos > xBound / correction)
        {
            xPos = xBound / correction;
        }
        else if (xPos < -xBound / correction)
        {
            xPos = -xBound / correction;
        }

        yPos = Mathf.Sqrt(Mathf.Pow(magnitudeline, 2) - Mathf.Pow(xPos, 2));
        initDirection = new Vector3(xPos, yPos, 0);

        lineRenderer.SetPosition(1, initDirection);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            initDirection = initDirection / magnitudeline;
            ballRb.AddForce(initDirection * initForce, ForceMode.Impulse);
            isOnPlayer = false;
            lineObject.SetActive(false);
        }
    }

    void HorizontalMove()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball") && !isOnPlayer){
            
            float yDirection;

            float xDirection = (collision.transform.position.x - transform.position.x) * angleMultiply / forceBall;

            if(Mathf.Abs(xDirection) < forceBall)
            {
                yDirection = Mathf.Sqrt(Mathf.Pow(forceBall, 2) - Mathf.Pow(xDirection, 2));
            }
            else
            {
                yDirection = 5;
            }

            Vector3 ballDirection = new Vector3(xDirection, yDirection, 0);
            
            ballRb.velocity = Vector3.zero;
            ballRb.AddForce(ballDirection * forceBall, ForceMode.Impulse);
        }
    }

}
