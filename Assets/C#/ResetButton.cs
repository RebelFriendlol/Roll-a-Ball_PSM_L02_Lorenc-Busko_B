using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject player; // Obiekt gracza
    public Transform spawnPoint; // Punkt respawnu pocz¹tkowego
    public CheckpointManager checkpointManager; // Odwo³anie do mened¿era checkpointów

    void Start()
    {
        ResetPlayerPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))  // Naciœnij R, aby zresetowaæ pozycjê
        {
            ResetPlayerPosition();
        }
    }

    public void ResetPlayerPosition()
    {
        if (checkpointManager.currentCheckpoint != null)
        {
            // Jeœli mamy aktywny checkpoint, zrespawnuj gracza w jego pozycji
            player.transform.position = checkpointManager.currentCheckpoint.position;
            player.transform.rotation = checkpointManager.currentCheckpoint.rotation; // Opcjonalnie, ustaw orientacjê
        }
        else
        {
            // Jeœli brak aktywnego checkpointa, zrespawnuj gracza w punkcie startowym
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation; // Opcjonalnie, ustaw orientacjê
        }
    }
}
