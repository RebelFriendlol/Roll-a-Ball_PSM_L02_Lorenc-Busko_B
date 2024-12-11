using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public List<Transform> checkpoints; // Lista wszystkich checkpointów
    public Transform currentCheckpoint; // Aktualny checkpoint
    private int unlockedCheckpoints = 0; // Liczba odblokowanych checkpointów
    public GameObject player; // Referencja do gracza

    void Start()
    {
        if (checkpoints.Count > 0)
        {
            currentCheckpoint = checkpoints[0]; // Ustaw pierwszy checkpoint jako domyœlny
            MovePlayerToCheckpoint();
        }
    }

    public void UnlockNextCheckpoint(int scoreCost)
    {
        if (unlockedCheckpoints + 1 < checkpoints.Count) // SprawdŸ, czy istnieje kolejny checkpoint
        {
            unlockedCheckpoints++;
            Debug.Log("Odblokowano nowy checkpoint!");
        }
        else
        {
            Debug.Log("Wszystkie checkpointy zosta³y odblokowane.");
        }
    }

    public void SetCheckpoint()
    {
        if (unlockedCheckpoints < checkpoints.Count)
        {
            currentCheckpoint = checkpoints[unlockedCheckpoints];
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
        if (player.score >= 1)
        {
            player.score -= 1; // Odejmij punkty
            currentCheckpoint = checkpoint; // Ustaw jako aktualny checkpoint
            Debug.Log("Checkpoint aktywowany!");
            return true;
        }
        else
        {
            Debug.Log("Za ma³o punktów, aby aktywowaæ checkpoint!");
            return false;
        }
    }

    public void ActivateCheckpoint(Transform checkpoint)
    {
        currentCheckpoint = checkpoint;  // Ustawia aktualny checkpoint na ten, który zosta³ aktywowany
    }


}
