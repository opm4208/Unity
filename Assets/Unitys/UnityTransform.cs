using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityTransform : MonoBehaviour
{
    /************************************************************************
	 * Ʈ������ (Transform)
	 * 
	 * ���ӿ�����Ʈ�� ��ġ, ȸ��, ũ�⸦ �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �θ�-�ڽ� ���¸� �����ϴ� ������Ʈ
	 * ���ӿ�����Ʈ�� �ݵ�� �ϳ��� Ʈ������ ������Ʈ�� ������ ������ �߰� & ������ �� ����
	 ************************************************************************/

    private void Start()
    {
		TranslateMove();
    }

    private void TranslateMove()
	{
		transform.position= new Vector3(10,10,10);
		transform.localScale = new Vector3(3, 3, 3);

	}
}
