using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  
using UnityEngine.SceneManagement; 

public class MovementController : MonoBehaviour
{
    public float thrust = 0.5f;  
    public float jumpthrust = 10f;  
    public Rigidbody rb;  
    public int score = 0;  
    private bool w = false, a = false, s = false, d = false, space = false;  
    private bool isGrounded = false;
    AudioSource audioData;

    public Button nextstage;
    private bool isPaused = false;  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextstage.gameObject.SetActive(false);
        //nextstage.onClick.AddListener(LoadNextStage);
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
        space = Input.GetKey(KeyCode.Space);
    }

    void FixedUpdate()
    {
       
        if (w) rb.AddForce(0, 0, thrust);
        if (a) rb.AddForce(-thrust, 0, 0);
        if (s) rb.AddForce(0, 0, -thrust);
        if (d) rb.AddForce(thrust, 0, 0);

        
        if (space && isGrounded)
        {
            audioData.Play();
            rb.AddForce(0, jumpthrust, 0, ForceMode.Impulse);
        }
    }

  
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

  
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }


    /*public void LoadNextStage()
    {
        Time.timeScale = 1f;

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadScene(3); 
        }
        else
        {
            SceneManager.LoadScene(2); 
        }
    }
*/

    private void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0.0f; 
        }
        else
        {
            Time.timeScale = 1.0f;  
        }
    }
}
