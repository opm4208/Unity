using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayer : MonoBehaviour
{
    public GameObject gameObj;
    public Rigidbody rb;
    public int speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        gameObj.name = "Player";
        rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
