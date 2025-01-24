using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogikaPoziom1 : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    public Text Scoretext;
    public Text WinText;
    private bool _isPaused = false;
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
        SceneManager.LoadScene(3);
    }

    void OnTriggerEnter(Collider collision)
    {

        var movementController = collision.gameObject.GetComponent<MovementController>();
        movementController.score += 1;

        audioData.Play();
        Scoretext.text = "Score: " + movementController.score;


        if (movementController.score == 3)
        {
            TogglePause();
            WinText.text = "ESSA";
            Debug.Log("Brawo zdoby³eœ wszystkie punkty!");
            nextstage.gameObject.SetActive(true);

        }


        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }
}
