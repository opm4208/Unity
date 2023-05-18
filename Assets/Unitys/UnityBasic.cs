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
        // <게임 오브젝트 접근>
        // 컴포넌트가 붙어있는 게임오브젝트는 gameobject 속성을 이용하여 접근가능
        // 컴포넌트가 붙어있는 게임오브젝트

        //gameObject.name = "Player";     // 게임오브젝트의 이름 접근
        //gameObject.active = false;      // 게임오브젝트의 활성화 여부
        //gameObject.tag;                 // 게임오브젝트의 태그 접근
        //gameObject.layer;               // 게임오브젝트의 레이어 접근

        //Player = GameObject.Find("Player");   // 이름으로 찾기  하이라이커 창에서 위에서 아래순으로 탐색
        //Player = GameObject.FindGameObjectWithTag("Player");  // 태그로 찾기
        //Players = GameObject.FindGameObjectsWithTag("Player"); // 여러개 찾기 배열로 반환

        // <게임오브젝트 생성>
        //GameObject newObject = new GameObject();
        //GameObject newObject = new GameObject("이름 생성");
        //newObject.name = "New Game Object";

        // <게임오브젝트 삭제>
        //Destroy(gameObject);
        //Destroy(gameObject, 5f); // 5초뒤 삭제
    }

    public void ComponentBasic()
    {
        // <게임오브젝트 내 컴포넌트 접근>
        audioSource = GetComponent<AudioSource>();              // 컴포넌트에서 GetComponent를 사용할 경우 부착되어 있는 게임오브젝트를 기준으로 접근
        audioSource = gameObject.GetComponent<AudioSource>();   // 게임오브젝트의 컴포넌트 접근
        GetComponents<AudioSource>();                           // 여러개 접근 배열로 반환

        GetComponentInChildren<Rigidbody>();                    // 자식게임오브젝트 포함 컴포넌트 접근
        GetComponentsInChildren<Rigidbody>();                   // 자식게임오브젝트 포함 여러 컴포넌트 접근
        gameObject.GetComponentInChildren<AudioSource>();       // 게임오브젝트의 자식게임오브젝트 포함 

        GetComponentInParent<Rigidbody>();                      // 부모게임오브젝트 포함 컴포넌트 접근
        GetComponentsInParent<Rigidbody>();                     // 부모게임오브젝트 포함 여러 컴포넌트 접근
        gameObject.GetComponentInParent<AudioSource>();         // 게임오브젝트의 부모게임오브젝트 포함 

        // <컴포넌트 탐색>    // 찾는데 오래걸림
        FindObjectOfType<AudioSource>();                        // 씬 내의 컴포넌트 탐색
        FindObjectsOfType<AudioSource>();                       // 씬 내의 모든 컴포넌트 탐색

        // <컴포넌트 추가>
        // Rigidbody rigid = new Rigidbody();	                // 가능하나 의미없음, 컴포넌트는 게임오브젝트에 부착되어 동작함에 의미가 있음
        AudioSource source = gameObject.AddComponent<AudioSource>();                 // 게임오브젝트에 컴포넌트 추가

        // <컴포넌트 삭제>
        Destroy(GetComponent<Collider>());
    }
}
