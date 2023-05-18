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
        //transform.Translate(moveDir*moveSpeed*Time.deltaTime); // 물체의 바라보는 방향으로 이동
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);// 세상을 기준으로 이동
        //transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.Self); // 물체를 기준으로 이동
        // x : 1/s 한프레임당 걸리는 시간 
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
        // 트랜스폼의 회전값은 Euler각도 표현이 아닌 Quaternion을 사용함
        transform.rotation = Quaternion.identity;

        // Euler각도를 Quaternion으로 변환
        transform.rotation = Quaternion.Euler(0, 90, 0);
    }

    // <Quarternion & Euler>
    // Quarternion	: 유니티의 게임오브젝트의 3차원 방향을 저장하고 이를 방향에서 다른 방향으로의 상대 회전으로 정의
    //				  기하학적 회전으로 짐벌락 현상이 발생하지 않음
    // EulerAngle	: 3축을 기준으로 각도법으로 회전시키는 방법
    //				  직관적이지만 짐벌락 현상이 발생하여 회전이 겹치는 축이 생길 수 있음
    // 짐벌락		: 같은 방향으로 오브젝트의 두 회전 축이 겹치는 현상

    // Quarternion을 통해 회전각도를 계산하는 것은 직관적이지 않고 이해하기 어려움
    // 보통의 경우 쿼터니언 -> 오일러각도 -> 연산진행 -> 결과오일러각도 -> 결과쿼터니언 과 같이 연산의 결과 쿼터니언을 사용함
    // <트랜스폼 부모-자식 상태>
    // 트랜스폼은 부모 트랜스폼을 가질 수 있음
    // 부모 트랜스폼이 있는 경우 부모 트랜스폼의 위치, 회전, 크기 변경이 같이 적용됨
    // 이를 이용하여 계층적 구조를 정의하는데 유용함 (ex. 팔이 움직이면, 손가락도 같이 움직임)
    // 하이어라키 창 상에서 드래그 & 드롭을 통해 부모-자식 상태를 변경할 수 있음
    private void TransformParent()
    {
        GameObject newGameObject = new GameObject() { name = "NewGameObject" };

        // 부모 지정
        transform.parent = newGameObject.transform;

        // 부모를 기준으로한 트랜스폼
        // transform.localPosition	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 위치
        // transform.localRotation	: 부모트랜스폼이 있는 경우 부모를 기준으로 한 회전
        // transform.localScale		: 부모트랜스폼이 있는 경우 부모를 기준으로 한 크기

        // 부모 해제
        transform.parent = null;

        // 월드를 기준으로한 트랜스폼
        // transform.localPosition == transform.position	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 위치
        // transform.localRotation == transform.rotation	: 부모트랜스폼이 없는 경우 월드를 기준으로 한 회전
        // transform.localScale								: 부모트랜스폼이 없는 경우 월드를 기준으로 한 크기
    } 
    private void Jump()
    {
        //rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }
    private void OnMove(InputValue value)
    {
        moveDir.x = value.Get<Vector2>().x; // 왼쪽 오른쪽
        moveDir.z = value.Get<Vector2>().y; // 위 아래
    }
    private void OnJump(InputValue value)
    {
        Jump();
    }
}
