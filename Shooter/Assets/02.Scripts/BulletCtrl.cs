using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();//제너릭 타입(Generic) GetComponent<T>()
        rb.AddRelativeForce(Vector3.forward * 800.0f);

    }

    //안쓰는 콜백함수들은 반드시 지운다!
}
