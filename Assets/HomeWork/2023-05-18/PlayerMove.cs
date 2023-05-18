using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    private Vector3 moveDir;
    private Vector3 movex;

    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;

    private void Start()
    {
        movex = moveDir;
    }

    private void Update()
    {
        Move();
        Rotate();
    }
    private void Move()
    {
        transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self);
    }
    public void Rotate()
    {
        transform.Rotate(Vector3.up, movex.x * rotateSpeed * Time.deltaTime, Space.Self);
    }
    private void OnMove(InputValue value)
    {
        movex.x = value.Get<Vector2>().x; // 왼쪽 오른쪽
        moveDir.z = value.Get<Vector2>().y; // 위 아래
    }
}
