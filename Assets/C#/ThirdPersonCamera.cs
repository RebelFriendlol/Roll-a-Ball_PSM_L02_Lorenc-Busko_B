using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;            // Obiekt gracza, wokó³ którego obraca siê kamera
    public float distance = 5f;         // Odleg³oœæ kamery od gracza
    public float height = 2f;           // Wysokoœæ kamery nad graczem
    public float rotationSpeed = 5f;    // Prêdkoœæ obracania kamery

    private float _currentYaw = 0f;      // Aktualny obrót wokó³ osi Y
    private float _currentPitch = 0f;    // Aktualny obrót wokó³ osi X
    public float minPitch = -30f;       // Minimalny k¹t nachylenia kamery
    public float maxPitch = 60f;        // Maksymalny k¹t nachylenia kamery

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Nie przypisano obiektu gracza do kamery!");
            return;
        }

        
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        
        _currentYaw += mouseX;

       
        _currentPitch -= mouseY;
        _currentPitch = Mathf.Clamp(_currentPitch, minPitch, maxPitch);

       
        Quaternion rotation = Quaternion.Euler(_currentPitch, _currentYaw, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);
        transform.position = target.position + offset;

      
        transform.LookAt(target.position + Vector3.up * height);
    }
}
