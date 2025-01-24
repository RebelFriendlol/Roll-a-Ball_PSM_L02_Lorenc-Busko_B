using UnityEngine;

public class CheckpointActivator : MonoBehaviour
{
    private CheckpointManager _checkpointManager;
    public Transform checkpoint; 
   

    void Start()
    {
        

        _checkpointManager = FindObjectOfType<CheckpointManager>();
        if (_checkpointManager == null)
        {
            Debug.LogError("CheckpointManager nie znaleziony!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            var player = other.GetComponent<MovementController>();
            if (player != null && _checkpointManager != null)
            {
                bool activated = _checkpointManager.TryActivateCheckpoint(checkpoint, player);
                if (activated)
                {
                    Debug.Log("Checkpoint aktywowany przez gracza.");
                    
                }
            }
        }
    }
}
