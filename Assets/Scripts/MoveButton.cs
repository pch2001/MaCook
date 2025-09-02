using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButton : MonoBehaviour
{
    public float moveDistance = 3f;   // 위아래 이동 거리
    public float speed = 2f;          // 이동 속도
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;  // 시작 위치 저장
    }

    void Update()
    {
        // PingPong은 0 ~ moveDistance 사이를 왕복
        float offset = Mathf.PingPong(Time.time * speed, moveDistance);

        // Y축 기준으로만 이동
        transform.position = new Vector3(startPos.x, startPos.y - moveDistance / 2f + offset, startPos.z);
    }

}
