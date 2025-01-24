using UnityEngine;

public class Licznik: MonoBehaviour
{
    public static Licznik Instance;

    public int playerScore = 0;
    public int deathCount = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Utrzymuje ten obiekt pomiêdzy scenami
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        playerScore += amount;
        Debug.Log($"Score updated: {playerScore}");
    }

    public void AddDeath()
    {
        deathCount++;
        Debug.Log($"Death count updated: {deathCount}");
    }
}
