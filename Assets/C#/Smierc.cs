using UnityEngine;

public class smierc : MonoBehaviour
{
    public GameObject player;
    public CheckpointManager checkpointManager;
    public string resetSurfaceTag = "smierc";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(resetSurfaceTag))
        {
            Debug.Log("reset");
            Licznik.Instance.AddDeath(); // Dodanie do licznika œmierci
            ResetToCheckpoint();
        }
    }

    public void ResetToCheckpoint()
    {
        if (checkpointManager.currentCheckpoint != null)
        {
            player.transform.position = checkpointManager.currentCheckpoint.position;
            player.transform.rotation = checkpointManager.currentCheckpoint.rotation;
        }
        else
        {
            Debug.LogWarning("Brak ustawionego checkpointa!");
        }
    }
}