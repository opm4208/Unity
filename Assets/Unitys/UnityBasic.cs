using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityBasic : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject Player;
    public GameObject[] Players;

    private void Start()
    {
        GameObjectBasic();
        ComponentBasic();
    }
    public void GameObjectBasic()
    {
        // <���� ������Ʈ ����>
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ�� gameobject �Ӽ��� �̿��Ͽ� ���ٰ���
        // ������Ʈ�� �پ��ִ� ���ӿ�����Ʈ

        //gameObject.name = "Player";     // ���ӿ�����Ʈ�� �̸� ����
        //gameObject.active = false;      // ���ӿ�����Ʈ�� Ȱ��ȭ ����
        //gameObject.tag;                 // ���ӿ�����Ʈ�� �±� ����
        //gameObject.layer;               // ���ӿ�����Ʈ�� ���̾� ����

        //Player = GameObject.Find("Player");   // �̸����� ã��  ���̶���Ŀ â���� ������ �Ʒ������� Ž��
        //Player = GameObject.FindGameObjectWithTag("Player");  // �±׷� ã��
        //Players = GameObject.FindGameObjectsWithTag("Player"); // ������ ã�� �迭�� ��ȯ

        // <���ӿ�����Ʈ ����>
        //GameObject newObject = new GameObject();
        //GameObject newObject = new GameObject("�̸� ����");
        //newObject.name = "New Game Object";

        // <���ӿ�����Ʈ ����>
        //Destroy(gameObject);
        //Destroy(gameObject, 5f); // 5�ʵ� ����
    }

    public void ComponentBasic()
    {
        // <���ӿ�����Ʈ �� ������Ʈ ����>
        audioSource = GetComponent<AudioSource>();              // ������Ʈ���� GetComponent�� ����� ��� �����Ǿ� �ִ� ���ӿ�����Ʈ�� �������� ����
        audioSource = gameObject.GetComponent<AudioSource>();   // ���ӿ�����Ʈ�� ������Ʈ ����
        GetComponents<AudioSource>();                           // ������ ���� �迭�� ��ȯ

        GetComponentInChildren<Rigidbody>();                    // �ڽİ��ӿ�����Ʈ ���� ������Ʈ ����
        GetComponentsInChildren<Rigidbody>();                   // �ڽİ��ӿ�����Ʈ ���� ���� ������Ʈ ����
        gameObject.GetComponentInChildren<AudioSource>();       // ���ӿ�����Ʈ�� �ڽİ��ӿ�����Ʈ ���� 

        GetComponentInParent<Rigidbody>();                      // �θ���ӿ�����Ʈ ���� ������Ʈ ����
        GetComponentsInParent<Rigidbody>();                     // �θ���ӿ�����Ʈ ���� ���� ������Ʈ ����
        gameObject.GetComponentInParent<AudioSource>();         // ���ӿ�����Ʈ�� �θ���ӿ�����Ʈ ���� 

        // <������Ʈ Ž��>    // ã�µ� �����ɸ�
        FindObjectOfType<AudioSource>();                        // �� ���� ������Ʈ Ž��
        FindObjectsOfType<AudioSource>();                       // �� ���� ��� ������Ʈ Ž��

        // <������Ʈ �߰�>
        // Rigidbody rigid = new Rigidbody();	                // �����ϳ� �ǹ̾���, ������Ʈ�� ���ӿ�����Ʈ�� �����Ǿ� �����Կ� �ǹ̰� ����
        AudioSource source = gameObject.AddComponent<AudioSource>();                 // ���ӿ�����Ʈ�� ������Ʈ �߰�

        // <������Ʈ ����>
        Destroy(GetComponent<Collider>());
    }
}
