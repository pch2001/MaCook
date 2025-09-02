using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public float moveDistance = 3f;   // ���Ʒ� �̵� �Ÿ�
    public float speed = 2f;          // �̵� �ӵ�
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;  // ���� ��ġ ����
    }

    void Update()
    {
        // PingPong�� 0 ~ moveDistance ���̸� �պ�
        float offset = Mathf.PingPong(Time.time * speed, moveDistance);

        // Y�� �������θ� �̵�
        transform.position = new Vector3(startPos.x, startPos.y - moveDistance / 2f + offset, startPos.z);
    }

}
