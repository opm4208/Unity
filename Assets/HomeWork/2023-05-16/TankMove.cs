using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMove : MonoBehaviour
{
    private Vector3 moveDir;
    private Vector3 movex;
    private CinemachineVirtualCamera virtualCamera;

    [SerializeField]
    private float rotateSpeed;
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPoint;
    [SerializeField]
    private float repeatTime;
    [SerializeField]
    private GameObject zoomcamera;
    [SerializeField]
    private AudioSource firesound;
    [SerializeField]
    private AudioSource movesound;


    private void Start()
    {
        movex = moveDir;
        virtualCamera = zoomcamera.GetComponent<CinemachineVirtualCamera>();
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
    private Coroutine bulletRoutine;

    private void OnFire(InputValue value)
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        firesound.Play();
        //obj.transform.position = transform.position; 
        //obj.transform.rotation = transform.rotation;
    }

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            firesound.Play();
            yield return new WaitForSeconds(repeatTime);
        }
    }
    private void OnRepeatFire(InputValue value)
    {
        if (value.isPressed)
        {
            bulletRoutine = StartCoroutine(BulletMakeRoutine());
        }
        else
        {
            StopCoroutine(bulletRoutine);
        }
    }
    private void OnZoomin(InputValue value)
    {
        if(value.isPressed)
        {
            virtualCamera.Priority = 100;
        }
        else
        {
            virtualCamera.Priority = 10;
        }
    }
}
