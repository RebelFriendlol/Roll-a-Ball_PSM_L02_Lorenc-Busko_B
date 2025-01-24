using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject player; // Obiekt gracza
    public Transform spawnPoint; // Punkt respawnu

    void Start()
    {
        var checkpointManager = FindObjectOfType<CheckpointManager>();
        if (checkpointManager != null)
        {
            checkpointManager.MovePlayerToCheckpoint();
        }
        else
        {
            Debug.LogWarning("CheckpointManager nie zosta³ znaleziony!");
        }
    }
}