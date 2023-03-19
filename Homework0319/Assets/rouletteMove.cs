using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rouletteMove : MonoBehaviour
{
    float rotSpeed = 0;
    public int chance;
    public bool startGame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !startGame)
        {
            Debug.Log("마우스 클릭 입력됨");
            rotSpeed += 10;
        }

        transform.Rotate(0, 0, rotSpeed); // 회전속도만큼 룰렛을 회전시킴
        rotSpeed *= 0.992f;

        if (rotSpeed < 0.01f && rotSpeed != 0)
        {

            // Debug.Log($"{transform.rotation.eulerAngles.z}");

            if (transform.rotation.eulerAngles.z % 360 + 30 <= 60)
                chance = 2; //Debug.Log("운수 나쁨");
            else if (transform.rotation.eulerAngles.z % 360 + 30 <= 120)
                chance = 6; //Debug.Log("운수 대통");
            else if (transform.rotation.eulerAngles.z % 360 + 30 <= 180)
                chance = 1; //Debug.Log("운수 매우 나쁨");
            else if (transform.rotation.eulerAngles.z % 360 + 30 <= 240)
                chance = 4; //Debug.Log("운수 보통");
            else if (transform.rotation.eulerAngles.z % 360 + 30 <= 300)
                chance = 3; //Debug.Log("운수 조심");
            else
                chance = 5; //Debug.Log("운수 좋음");

            rotSpeed = 0;
            startGame = true;
        }
    }
}
