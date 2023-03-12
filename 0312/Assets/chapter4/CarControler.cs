using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarControler : MonoBehaviour
{
    public float speed = 0;
    Vector2 startPos;
    public float swipeLength;
    GameObject camera;
    CarGameManager carGameManager;
    public int count = 0;
    GameObject distanceText;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");
        carGameManager = camera.GetComponent<CarGameManager>();
        distanceText = GameObject.Find("Distance");
    }

    // Update is called once per frame
    void Update()
    {
        if (carGameManager.status)
        {
            if (speed < 0.01f)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startPos = Input.mousePosition;
                }
                else if (Input.GetMouseButtonUp(0))
                {
                    Vector2 endPos = Input.mousePosition;
                    swipeLength = endPos.x - startPos.x;
                    speed = swipeLength / 1500.0f;
                    count++;

                    GetComponent<AudioSource>().Play();
                }
            }
            if (count > 5)
            {
                carGameManager.status = false;
                distanceText.GetComponent<TMP_Text>().text = "Lose..";
            }
        }
            transform.Translate(speed, 0, 0);
            speed *= 0.98f;
        if (Input.GetKey(KeyCode.R))
        {
            count = 0;
            speed = 0;
            transform.position = new Vector3(-7, -3.7f, 0);
            carGameManager.status = true;
        }
    }
}
