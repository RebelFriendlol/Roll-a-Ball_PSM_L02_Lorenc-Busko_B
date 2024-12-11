using UnityEngine;

public class CheckpointActivator : MonoBehaviour
{
    private CheckpointManager checkpointManager;
    public Transform checkpoint; // Ten checkpoint, który ma zostaæ aktywowany

    void Start()
    {
        checkpointManager = FindObjectOfType<CheckpointManager>();
        if (checkpointManager == null)
        {
            Debug.LogError("CheckpointManager nie znaleziony!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // SprawdŸ, czy dotkniêcie jest przez gracza
        {
            var player = other.GetComponent<MovementController>();
            if (player != null && checkpointManager != null)
            {
                bool activated = checkpointManager.TryActivateCheckpoint(checkpoint, player);
                if (activated)
                {
                    Debug.Log("Checkpoint aktywowany przez gracza.");
                    // Mo¿esz dodaæ efekty wizualne lub dŸwiêkowe tutaj
                }
            }
        }
    }
}
