using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class koniecgry : MonoBehaviour
{
    public Button wyjdzzgry;
    
    void Start()
    {
        wyjdzzgry.onClick.AddListener(Exit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
