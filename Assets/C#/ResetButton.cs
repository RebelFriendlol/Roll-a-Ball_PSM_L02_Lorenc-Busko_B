using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public GameObject player; 
    public Transform spawnPoint; 
    public CheckpointManager checkpointManager; 

    void Start()
    {
        ResetPlayerPosition();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))  
        {
            ResetPlayerPosition();
        }
    }

    public void ResetPlayerPosition()
    {
        if (checkpointManager.currentCheckpoint != null)
        {
            player.transform.position = checkpointManager.currentCheckpoint.position;
            player.transform.rotation = checkpointManager.currentCheckpoint.rotation;
        }
        else
        {
            player.transform.position = spawnPoint.position;
            player.transform.rotation = spawnPoint.rotation; 
        }
    }
}
