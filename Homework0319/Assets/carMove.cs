using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMove : MonoBehaviour
{
    GameObject roulette;
    rouletteMove RouletteMove;
    public float speed = 0;
    bool accel = true;
    public int remainChance;
    bool chanceRoad = true;
    GameObject camera;
    carGameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        roulette = GameObject.Find("roulette");
        camera = GameObject.Find("Main Camera");
        RouletteMove = roulette.GetComponent<rouletteMove>();
        manager = camera.GetComponent<carGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chanceRoad)
        {
            remainChance = RouletteMove.chance;
            if (remainChance > 0)
                chanceRoad = false;
        }
        if (manager.status)
        {
            if (RouletteMove.startGame && remainChance > 0)
            {
                if (accel && Input.GetMouseButton(0))
                {
                    speed += 0.0003f;
                }

                if (Input.GetMouseButtonUp(0) && accel)
                {
                    remainChance--;
                    accel = false;
                }
            }
        }

        if (!accel)
        {
            transform.Translate(speed, 0, 0);
            speed *= 0.992f;
        }
        
        if (speed < 0.001f && speed != 0 && !accel)
        {
            speed = 0;
            accel = true;
        }
    }
}
