using UnityEngine;

public class timestart : MonoBehaviour
{
    

    private bool isPaused = false;
    void Start()
    {
        isPaused = true;
        TogglePause();
    }

 
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
