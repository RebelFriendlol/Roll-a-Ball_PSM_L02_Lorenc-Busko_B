using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementController : MonoBehaviour
{
    public float thrust = 10f;
    public float jumpthrust = 10f;
    public Rigidbody rb;
    public Transform cameraTransform;  // Referencja do kamery
    public int score = 0;
    private bool isGrounded = false;
    private AudioSource audioData;


    public Button nextstage;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextstage.gameObject.SetActive(false);
        audioData = GetComponent<AudioSource>();

        if (cameraTransform == null)
        {
            Debug.LogError("Brak przypisanej kamery w skrypcie MovementController!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

       

    }

    void FixedUpdate()
    {
        Move();
    }


   

   
        private void Move()
    {
        // Pobierz ruch w osi X i Z na podstawie wciœniêtych klawiszy
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Kierunek ruchu w przestrzeni kamery
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // Ustaw wektory tylko w p³aszczyŸnie poziomej
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Oblicz kierunek ruchu
        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        // Dodaj si³ê w kierunku ruchu
        rb.AddForce(moveDirection * thrust);
    }

    private void Jump()
    {
        audioData.Play();
        rb.AddForce(Vector3.up * jumpthrust, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    

   

}
