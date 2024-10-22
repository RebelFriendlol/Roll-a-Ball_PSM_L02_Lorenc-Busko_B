using UnityEngine;

public class timestart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private bool isPaused = false;
    void Start()
    {
        isPaused = true;
        TogglePause();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void TogglePause()
    {
        

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
