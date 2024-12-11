using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;            // Obiekt gracza, wokó³ którego obraca siê kamera
    public float distance = 5f;         // Odleg³oœæ kamery od gracza
    public float height = 2f;           // Wysokoœæ kamery nad graczem
    public float rotationSpeed = 5f;    // Prêdkoœæ obracania kamery

    private float currentYaw = 0f;      // Aktualny obrót wokó³ osi Y
    private float currentPitch = 0f;    // Aktualny obrót wokó³ osi X
    public float minPitch = -30f;       // Minimalny k¹t nachylenia kamery
    public float maxPitch = 60f;        // Maksymalny k¹t nachylenia kamery

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Nie przypisano obiektu gracza do kamery!");
            return;
        }

        // Pobieranie ruchu myszy
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        // Obrót wokó³ osi Y
        currentYaw += mouseX;

        // Obrót wokó³ osi X z ograniczeniem k¹ta
        currentPitch -= mouseY;
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);

        // Ustawienie pozycji kamery
        Quaternion rotation = Quaternion.Euler(currentPitch, currentYaw, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);
        transform.position = target.position + offset;

        // Kamera zawsze patrzy na gracza
        transform.LookAt(target.position + Vector3.up * height);
    }
}
