using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    
    //Animation 컴포넌트를 정장할 변수
    private Animation anim;
    //이동 속력 변수(public으로 선언되어 인스펙터 뷰에 노출됨)
    public float moveSpeed=10.0f;
    
    //회전 속도 변수
    public float turnSpeed=80.0f;
    void Start()
    {
        //컴포넌트를 추출해 변수에 대입
        tr = GetComponent<Transform>();
        anim=GetComponent<Animation>();

        //애니메이션 실ㅇ
        anim.Play("Idle");
        
    }
    
    void Update()
    {
        float h=Input.GetAxis("Horizontal"); //-1.0f~0.0f~+1.0f
        float v=Input.GetAxis("Vertical"); //-1.0f~0.0f~+1.0f
        float r=Input.GetAxis("Mouse X");

        //Debug.Log("h="+h);
        //Debug.Log("v="+v);

        //Transform 컴포넌트의 position 속성값을 변경
        //transform.position += new Vector3(0,0,1);

        //정규화 벡터를 사용한 코드
        //tr.position +=Vector3.forward*1;

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir=(Vector3.forward * v)+(Vector3.right * h);

        //Translate 함수를 사용한 이동 로직(이동 방향*속력*Time.deltaTime)
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }
}
