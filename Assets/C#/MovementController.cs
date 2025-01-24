using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events; // Dodajemy UnityEvent

public class MovementController : MonoBehaviour
{
    public float thrust = 10f;
    public float jumpthrust = 10f;
    public Rigidbody rb;
    public Transform cameraTransform;
    public int score = 0;
    private bool _isGrounded = false;
    private AudioSource _audioData;

    public Button nextstage;
    public UnityEvent onScoreUpdated; // Dodajemy event

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nextstage.gameObject.SetActive(false);
        _audioData = GetComponent<AudioSource>();

        if (cameraTransform == null)
        {
            Debug.LogError("Brak przypisanej kamery w skrypcie MovementController!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
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
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * vertical + right * horizontal).normalized;

        rb.AddForce(moveDirection * thrust);
    }

    private void Jump()
    {
        _audioData.Play();
        rb.AddForce(Vector3.up * jumpthrust, ForceMode.Impulse);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGrounded = false;
        }
    }

    public void UpdateScore(int amount)
    {
        score += amount;
       Licznik.Instance.AddScore(amount); // Aktualizacja wyniku w GameManagerze
        Debug.Log("UpdateScore called. Amount: " + amount + ", New Score: " + score);
        onScoreUpdated?.Invoke();
    }

}
