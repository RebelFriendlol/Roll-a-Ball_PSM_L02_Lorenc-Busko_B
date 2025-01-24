using UnityEngine;
using UnityEngine.SceneManagement;

public class KoniecGry : MonoBehaviour
{
    [Tooltip("Numer sceny do za³adowania lub jej nazwa.")]
    public string s_sceneName;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
         
            LoadScene();
        }
    }

    private void LoadScene()
    {
        if (!string.IsNullOrEmpty(s_sceneName))
        {
            SceneManager.LoadScene(s_sceneName);
        }
        else
        {
            Debug.LogError("Nie ustawiono nazwy sceny w inspectorze!");
        }
    }
}
