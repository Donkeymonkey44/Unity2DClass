using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarGameManager : MonoBehaviour
{
    CarControler carControler;

    GameObject car;
    GameObject flag;
    GameObject distanceText;
    public bool status = true;
    float highestScore;
    bool issave;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("car");
        flag = GameObject.Find("flag");
        distanceText = GameObject.Find("Distance");

        carControler = car.GetComponent<CarControler>();
        issave = PlayerPrefs.HasKey("SaveScore");
        if (!issave)
        {
            highestScore = 0.5f;
        }
        else
        {
            highestScore = PlayerPrefs.GetFloat("SaveScore");
        }    
    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        if (status)
        {
            distanceText.GetComponent<TMP_Text>().text = "Distance : " + length.ToString("F2") + "m";
            if (length < 0)
            {
                distanceText.GetComponent<TMP_Text>().text = "Lose..";
                status = false;
            }
            else if (length <= 0.5f && carControler.speed < 0.01f)
            {
                distanceText.GetComponent<TMP_Text>().text = "Win!!";
                status = false;
                if (highestScore <= length)
                {
                    Debug.Log("��� ���� ����");
                    Debug.Log($"�ְ� ����� ���� {highestScore} �Դϴ�.");
                }
                else
                {
                    Debug.Log("��� ���� ����");
                    PlayerPrefs.SetFloat("SaveScore", length);
                    Debug.Log($"�ְ� ����� {length} �� �Ǿ����ϴ�.");
                }
            }
        }
    }
}
