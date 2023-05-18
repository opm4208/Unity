using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestBullet : MonoBehaviour
{
    public GameObject bullet;
    
    private void Fire()
    {
        GameObject newObject = new GameObject();
        newObject = bullet;
    }
    private void OnFire(InputValue value)
    {
        Fire();
    }
}
