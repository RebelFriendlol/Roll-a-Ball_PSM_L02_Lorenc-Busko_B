using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointManager : MonoBehaviour
{
    public List<Transform> checkpoints;
    public Transform currentCheckpoint;
    private int _unlockedCheckpoints = 0;
    public GameObject player;

    // Dodajemy listê do przechowywania aktywowanych checkpointów
    private List<bool> activatedCheckpoints;

    // Dodajemy zmienn¹ do œledzenia kosztu aktywacji
    private int checkpointCost = 1;

    void Start()
    {
        activatedCheckpoints = new List<bool>(new bool[checkpoints.Count]); // Zainicjowanie listy z wartoœciami false

        if (checkpoints.Count > 0)
        {
            currentCheckpoint = checkpoints[0];
            MovePlayerToCheckpoint();
        }
    }

    public void UnlockNextCheckpoint(int scoreCost)
    {
        if (_unlockedCheckpoints + 1 < checkpoints.Count)
        {
            _unlockedCheckpoints++;
            Debug.Log($"Odblokowano nowy checkpoint! Koszt: {scoreCost} punktów.");
        }
        else
        {
            Debug.Log("Wszystkie checkpointy zosta³y odblokowane.");
        }
    }

    public void SetCheckpoint()
    {
        if (_unlockedCheckpoints < checkpoints.Count)
        {
            currentCheckpoint = checkpoints[_unlockedCheckpoints];
            Debug.Log("Ustawiono nowy aktualny checkpoint.");
        }
    }

    public void MovePlayerToCheckpoint()
    {
        if (currentCheckpoint != null && player != null)
        {
            player.transform.position = currentCheckpoint.position;
            player.transform.rotation = currentCheckpoint.rotation;
        }
        else
        {
            Debug.LogWarning("Checkpoint lub gracz nie zosta³ przypisany!");
        }
    }

    public bool TryActivateCheckpoint(Transform checkpoint, MovementController player)
    {
        int checkpointIndex = checkpoints.IndexOf(checkpoint);

        if (checkpointIndex == -1)
        {
            Debug.LogWarning("Nie znaleziono checkpointa!");
            return false;
        }

        // SprawdŸ, czy checkpoint zosta³ ju¿ aktywowany
        if (activatedCheckpoints[checkpointIndex])
        {
            Debug.Log("Ten checkpoint zosta³ ju¿ aktywowany!");
            return false;
        }

        if (player.score >= checkpointCost)
        {
            player.score -= checkpointCost;
            currentCheckpoint = checkpoint;
            activatedCheckpoints[checkpointIndex] = true; // Oznacz checkpoint jako aktywowany
            Debug.Log($"Checkpoint aktywowany! Koszt: {checkpointCost}");

            // Zwiêkszenie kosztu kolejnego checkpointa
            checkpointCost++;

            // Aktualizacja Scoretext
            var scoreText = FindObjectOfType<Text>();
            if (scoreText != null)
            {
                scoreText.text = "Score: " + player.score;
            }

            return true;
        }
        else
        {
            Debug.Log($"Za ma³o punktów, aby aktywowaæ checkpoint! Potrzebujesz: {checkpointCost}");
            return false;
        }
    }

    public void ActivateCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;
    }

    public bool IsCheckpointActivated(int checkpointIndex)
    {
        if (checkpointIndex >= 0 && checkpointIndex < activatedCheckpoints.Count)
        {
            return activatedCheckpoints[checkpointIndex];
        }

        return false;
    }


}

