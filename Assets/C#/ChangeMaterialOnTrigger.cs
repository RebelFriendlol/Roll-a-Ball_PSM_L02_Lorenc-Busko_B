using UnityEngine;

public class ChangeMaterialOnTrigger : MonoBehaviour
{
    public Material newMaterial; // Materia³ po aktywacji
    private Renderer[] _objectRenderers; // Lista Rendererów
    public Transform checkpoint; // Przypisany checkpoint

    private CheckpointManager _checkpointManager; // Odwo³anie do CheckpointManager
    private bool _isActivated = false; // Czy checkpoint zosta³ aktywowany

    void Start()
    {
        _objectRenderers = GetComponentsInChildren<Renderer>();
        _checkpointManager = FindObjectOfType<CheckpointManager>();

        if (_objectRenderers.Length == 0)
        {
            Debug.LogWarning("Brak komponentów Renderer na obiekcie lub jego dzieciach: " + gameObject.name);
        }

        if (_checkpointManager == null)
        {
            Debug.LogError("CheckpointManager nie zosta³ znaleziony w scenie!");
        }
    }

    void Update()
    {
        if (!_isActivated && _checkpointManager != null)
        {
            int checkpointIndex = _checkpointManager.checkpoints.IndexOf(checkpoint);

            if (checkpointIndex != -1 && _checkpointManager.IsCheckpointActivated(checkpointIndex))
            {
                _isActivated = true;
                ChangeMaterial();
            }
        }
    }

    private void ChangeMaterial()
    {
        if (_objectRenderers.Length > 0 && newMaterial != null)
        {
            foreach (Renderer rend in _objectRenderers)
            {
                rend.material = newMaterial;
                Debug.Log("Materia³ zmieniony na: " + rend.gameObject.name);
            }
        }
        else
        {
            Debug.LogWarning("Nie uda³o siê zmieniæ materia³u: brak materia³u lub Rendererów.");
        }
    }
}
