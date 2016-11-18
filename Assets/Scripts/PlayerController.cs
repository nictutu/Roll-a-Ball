using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text timerText;
    public Text winText;
    public Text perSecondText;
    public float timer;
    public bool gameOver;
    public float avg;

    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        timer = 0.0f;
        SetCountText();
        SetTimerText();
        winText.text = "";
        perSecondText.text = "";
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            timer += Time.deltaTime;
            SetTimerText();
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Application.Quit();
        }
    }
	void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
	}
    // Called when the object first touches a trigger collider other
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }
    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 14)
        {
            gameOver = true;
            winText.text = "You Win!";
            avg = 14.0f / timer;
            perSecondText.text = "Avg: " + avg.ToString();
        }
    }
    void SetTimerText()
    {
        timerText.text = "Timer: " + timer.ToString();
    }
}