using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public UnityEvent OnFired;

    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletPoint;
    [SerializeField]
    private float repeatTime;

    private Coroutine bulletRoutine;
    public void Fire()
    {
        GameObject obj = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
        GameManager.Data.AddShootCount(1);
        OnFired?.Invoke();
    }

    private void OnFire(InputValue value)
    {
        Fire();
    }

    IEnumerator BulletMakeRoutine()
    {
        while (true)
        {
            Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            GameManager.Data.AddShootCount(1);
            OnFired?.Invoke();
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
}
