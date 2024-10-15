using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poziom2collectable : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle * Time.deltaTime, yAngle * Time.deltaTime, zAngle * Time.deltaTime, Space.Self);




    }


    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<MovementController>().score += 1;
        Debug.Log("Masz: " + collision.gameObject.GetComponent<MovementController>().score + " punktów.");

        if (collision.gameObject.GetComponent<MovementController>().score == 5)
        {
            Debug.Log("Brawo zdoby³eœ wszystkie punkty!");
        }

        Destroy(gameObject);
    }
}
