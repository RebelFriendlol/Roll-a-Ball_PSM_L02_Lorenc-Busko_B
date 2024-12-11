using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class collectable : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public Text Scoretext;  
    public Text WinText;   
    private bool isPaused = false; 
    public Button nextstage;
    AudioSource audioData;

    void Start()
    {
        WinText.text = ""; 
        nextstage.gameObject.SetActive(false);
        audioData = GetComponent<AudioSource>();
    }

    void Update()
    {
        
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);
    }

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


    public void LoadNextStage()
    {
        Time.timeScale = 1f;   
        SceneManager.LoadScene(2);    
    }

    void OnTriggerEnter(Collider collision)
    {
        audioData.Play();
        var movementController = collision.gameObject.GetComponent<MovementController>();
        movementController.score += 1;

        Scoretext.text = "Score: " + movementController.score;

        var checkpointManager = FindObjectOfType<CheckpointManager>();
        if (checkpointManager != null && movementController.score >= 5) // Wymagana liczba punktów
        {
            checkpointManager.UnlockNextCheckpoint(5);
            checkpointManager.SetCheckpoint();
        }

        if (movementController.score == 3)
        {
            TogglePause();
            WinText.text = "ESSA";
            Debug.Log("Brawo zdoby³eœ wszystkie punkty!");
            nextstage.gameObject.SetActive(true);
        }

        GetComponent<Renderer>().enabled = false; // Ukryj obiekt
        GetComponent<Collider>().enabled = false; // Wy³¹cz collider
    }

}
