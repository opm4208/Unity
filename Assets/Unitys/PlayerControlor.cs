using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerControlor : MonoBehaviour
{
    private Vector3 moveDir;
    //private Rigidbody rb;

    [SerializeField]
    private float movePower;
    [SerializeField]
    private float jumpPower;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float rotateSpeed;
    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
       // Move();
        Rotate();
        //LookAt();

    }
    private void Move()
    {
        //transform.position += moveSpeed* moveDir*Time.deltaTime;
        //transform.Translate(moveDir*moveSpeed*Time.deltaTime); // ��ü�� �ٶ󺸴� �������� �̵�
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);// ������ �������� �̵�
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self); // ��ü�� �������� �̵�
        // x : 1/s �������Ӵ� �ɸ��� �ð� 
        //rb.AddForce(moveDir*movePower, ForceMode.Force);
    }

    public void Rotate()
    {
        transform.Rotate(Vector3.up, moveDir.x* rotateSpeed * Time.deltaTime, Space.Self);
    }
    public void LookAt()
    {
        transform.LookAt(new Vector3(0, 0, 0));
    }

    public void Rotation()
    {
        // Ʈ�������� ȸ������ Euler���� ǥ���� �ƴ� Quaternion�� �����
        transform.rotation = Quaternion.identity;

        // Euler������ Quaternion���� ��ȯ
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // <Quarternion & Euler>
    // Quarternion	: ����Ƽ�� ���ӿ�����Ʈ�� 3���� ������ �����ϰ� �̸� ���⿡�� �ٸ� ���������� ��� ȸ������ ����
    //				  �������� ȸ������ ������ ������ �߻����� ����
    // EulerAngle	: 3���� �������� ���������� ȸ����Ű�� ���
    //				  ������������ ������ ������ �߻��Ͽ� ȸ���� ��ġ�� ���� ���� �� ����
    // ������		: ���� �������� ������Ʈ�� �� ȸ�� ���� ��ġ�� ����

    // Quarternion�� ���� ȸ�������� ����ϴ� ���� ���������� �ʰ� �����ϱ� �����
    // ������ ��� ���ʹϾ� -> ���Ϸ����� -> �������� -> ������Ϸ����� -> ������ʹϾ� �� ���� ������ ��� ���ʹϾ��� �����
    // <Ʈ������ �θ�-�ڽ� ����>
    // Ʈ�������� �θ� Ʈ�������� ���� �� ����
    // �θ� Ʈ�������� �ִ� ��� �θ� Ʈ�������� ��ġ, ȸ��, ũ�� ������ ���� �����
    // �̸� �̿��Ͽ� ������ ������ �����ϴµ� ������ (ex. ���� �����̸�, �հ����� ���� ������)
    // ���̾��Ű â �󿡼� �巡�� & ����� ���� �θ�-�ڽ� ���¸� ������ �� ����
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // �θ� ����
        transform.parent = newGameObject.transform;

        // �θ� ���������� Ʈ������
        // transform.localPosition	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ��ġ
        // transform.localRotation	: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ȸ��
        // transform.localScale		: �θ�Ʈ�������� �ִ� ��� �θ� �������� �� ũ��

        // �θ� ����
        transform.parent = null;

        // ���带 ���������� Ʈ������
        // transform.localPosition == transform.position	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ��ġ
        // transform.localRotation == transform.rotation	: �θ�Ʈ�������� ���� ��� ���带 �������� �� ȸ��
        // transform.localScale								: �θ�Ʈ�������� ���� ��� ���带 �������� �� ũ��
    } 
    private void Jump()
    {
        //rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x; // ���� ������
        moveDir.z = value.Get<Vector2>().y; // �� �Ʒ�
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
}
