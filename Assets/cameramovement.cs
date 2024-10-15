using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramovement : MonoBehaviour
{
    public GameObject player;
    Vector3 gracz;
    Vector3 kamera;
    Vector3 Offset;

    // Start is called before the first frame update
    void Start()
    {
        
        //A = B - C roznica pomiedzu kamera a graczem
        Offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //B = C + A 
        transform.position = player.transform.position + Offset;
    }
}
