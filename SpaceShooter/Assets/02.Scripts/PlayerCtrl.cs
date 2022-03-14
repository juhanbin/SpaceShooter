using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    //컴포넌트를 캐시 처리할 변수
    private Transform tr;
    //이동변수
    public float moveSpeed=10.0f;
    void Start()
    {
        //컴포넌트를 추출해 변수에 대입
        tr=GetComponent<Transform>();
        
        
    }
    
    void Update()
    {
        float h=Input.GetAxis("Horizontal"); //-1.0f~0.0f~+1.0f
        float v=Input.GetAxis("Vertical"); //-1.0f~0.0f~+1.0f

        Debug.Log("h="+h);
        Debug.Log("v="+v);

        //Transform 컴포넌트의 position 속성값을 변경
        //transform.position += new Vector3(0,0,1);

        //정규화 벡터를 사용한 코드
        //tr.position +=Vector3.forward*1;

        //전후좌우 이동 방향 벡터 계산
        Vector3 moveDir=(Vector3.forward * v)+(Vector3.right * h);

        //Translate 함수를 사용한 이동 로직
        tr.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
