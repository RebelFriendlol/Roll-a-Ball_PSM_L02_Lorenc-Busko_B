using UnityEngine;
using UnityEngine.UI;

public class Wynik : MonoBehaviour
{
    public Text scoreText;
    public Text deathText;

    void Start()
    {
        scoreText.text = "Score: " + Licznik.Instance.playerScore;
        deathText.text = "Deaths: " + Licznik.Instance.deathCount;
    }
}
