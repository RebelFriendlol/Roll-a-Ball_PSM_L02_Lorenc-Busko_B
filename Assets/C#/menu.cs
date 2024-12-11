using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public Button nextstage;
    public Button wyjdz;

    void Start()
    {     
        nextstage.onClick.AddListener(StartGame);
        wyjdz.onClick.AddListener(Exit);
    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {

    }


    public void Exit()
    {
        Application.Quit();
    }


}
