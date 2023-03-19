using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class carGameManager : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject chance;
    GameObject distance;

    TMP_Text chanceText;
    TMP_Text distanceText;

    carMove carmove;
    int chanceInt;
    public bool status = true;
    public float length;

    // Start is called before the first frame update
    void Start()
    {
        car= GameObject.Find("car");
        flag = GameObject.Find("flag");
        chance = GameObject.Find("Chance");
        distance = GameObject.Find("Distance");
        carmove = car.GetComponent<carMove>();

        chanceText = chance.GetComponent<TMP_Text>();
        distanceText = distance.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        length = flag.transform.position.x - car.transform.position.x;
        chanceInt = carmove.remainChance;

        if (status)
        {
            chanceText.text = "Chance : " + chanceInt.ToString();
            distanceText.text = "Distance : " + length.ToString("F2") + "m";

            if (length == 15.2f)
                distanceText.text = "Game Start!";

            if (length < 0)
            {
                distanceText.text = "Lose...";
                status = false;
            }

            if (chanceInt == 0 && carmove.speed == 0 && length > 0.5 && length != 15.2f)
            {
                distanceText.text = "Lose...";
                status = false;
            }

            if (carmove.speed == 0 && length <= 0.5 && length >= 0)
            {
                distanceText.text = "Win !!";
                status = false;
            }
        }
    }
}
