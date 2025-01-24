using UnityEngine;

public class WyjscieZGry : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Gra zosta³a zamkniêta."); // Wyœwietlenie w konsoli, przydatne w trybie edytora
        Application.Quit(); // Zamyka grê (dzia³a tylko w wersji build)
    }
}