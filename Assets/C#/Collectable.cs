using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events; // Dodajemy UnityEvent

public class collectable : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public Text Scoretext;
    public Text WinText;
    private bool _isPaused = false;
    public Button nextstage;
    AudioSource audioData;
    public UnityEvent onCollected; // Dodajemy event zbierania

    void Start()
    {
        WinText.text = "";
        nextstage.gameObject.SetActive(false);
        audioData = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        Debug.Log("Rotacja dzia³a");
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);
    }

    private void TogglePause()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
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
        // Jeœli przedmiot ju¿ zosta³ zebrany, nie robimy nic
        if (!GetComponent<Renderer>().enabled)
            return;

        audioData.Play();

        // Wywo³anie eventu po zebraniu przedmiotu
        onCollected?.Invoke();  // Jeœli event doda punkty, nie musimy tego robiæ tu w kodzie

        var movementController = collision.gameObject.GetComponent<MovementController>();
        if (movementController != null)
        {
            // Teraz dodajemy punkty tylko raz przez event, nie wywo³ujemy UpdateScore bezpoœrednio
            Scoretext.text = "Score: " + movementController.score;

            var checkpointManager = FindObjectOfType<CheckpointManager>();
            if (checkpointManager != null && movementController.score >= 5)
            {
                checkpointManager.UnlockNextCheckpoint(5);
                checkpointManager.SetCheckpoint();
            }
        }

        // Ukrywamy obiekt po zebraniu
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }


}
