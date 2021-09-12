using System.Collections;
using System.Collections.Generic;
using UnityEngine;public class PlayerCtrl : MonoBehaviour
{

    private Animation anim;
    /*
    파스칼표기법-클래스, 메소드(함수)명
    낙타형 표기법-변수명
    */
    // 이동속도
    public float moveSpeed = 8.0f;
    // 회전속도
    public float turnSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {       //컴포넌트를 추출해서 변수에 대입
            anim=this.gameObject.GetComponent<Animation>();
            
            
            anim.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // -1.0f ~ 0.0f ~ +1.0f
        float v = Input.GetAxis("Vertical");  // -1.0f ~ 0.0f ~ +1.0f
        float r = Input.GetAxis("Mouse X");

        // (전진후진벡터) + (좌우벡터)
        Vector3 dir = (Vector3.forward * v) + (Vector3.right * h);

        // Debug.Log("dir=" + dir.magnitude);
        // Debug.Log("정규화 벡터 dir=" + dir.normalized.magnitude);

        // 이동처리
        transform.Translate(dir.normalized * Time.deltaTime * moveSpeed);

        // 회전처리
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * r);

        // 애니메이션 처리
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v)
    {
        if (v >= 0.1f) // 전진
        {
            // 애니메이션을 부드럽게 전환
            anim.CrossFade("RunF", 0.3f);
        }
        else if (v <= -0.1f) // 후진
        {
            anim.CrossFade("RunB", 0.3f);
        }
        else if (h >= 0.1f) // 오른쪽
        {
            anim.CrossFade("RunR", 0.3f);
        }
        else if (h <= -0.1f) // 왼쪽
        {
            anim.CrossFade("RunL", 0.3f);
        }
        else
        {
            anim.CrossFade("Idle", 0.3f);
        }
    }

}