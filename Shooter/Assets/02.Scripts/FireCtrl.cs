using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class FireCtrl : MonoBehaviour
{
    [SerializeField]
    private new AudioSource audio;

    public GameObject bulletPrefab;
    public Transform firePos;
    public AudioClip fireSfx;


[System.NonSerialized]
[HideInInspector]
    public MeshRenderer muzzelFlash;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        muzzelFlash = firePos.gameObject.GetComponentInChildren<MeshRenderer>();
        muzzelFlash.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) == true)
        {
            Fire();
       }
    }

    void Fire(){
            // 총알 생성
            // Instantiate (생성할객체, 위치, 각도)
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);
            audio.PlayOneShot(fireSfx, 0.8f);
            //총구화염효과
        StartCoroutine(ShowMuzzleFlash());
    }
    IEnumerator ShowMuzzleFlash(){
        /*(0,0),(0.5,0),(0,0.5),(0.5,0.5)
        Random.Range(0,3)==>0,1,2
        Random.Range(0.0f,3.0f)==>0.0f~3.0f*/
        //텍스쳐의 오프셋을 변경
        Vector2 offset = new Vector2(Random.Range(0,2) * 0.5f, Random.Range(0,2)*0.5f);
        muzzelFlash.material.mainTextureOffset = offset;

        //크기변경
        float scale = Random.Range(1.0f,3.0f);
        muzzelFlash.transform.localScale=Vector3.one * scale;//new Vector3(scale,scale,scale)
        //차일드로 들어간거 scale변경할려면localscale써야함

        //MuzzleFlash의 회전
        float angle = Random.Range(0,360);
        muzzelFlash.transform.localRotation = Quaternion.Euler(Vector3.forward * angle);


        //MeshRenderer컴포넌트를 비활성화
        muzzelFlash.enabled = true;

        //Waiting...
        yield return new WaitForSeconds(0.2f);

        //MeshRenderer컴포넌트를 활성화
        muzzelFlash.enabled = false;
    }
}
/*
    Muzzle Flash(총구화염)


*/