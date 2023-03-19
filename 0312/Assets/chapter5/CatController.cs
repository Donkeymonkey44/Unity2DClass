using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    GameObject arrow;
    float time;
    public bool getHit = true;
    SpriteRenderer renderer;
    bool isOn = false;
    int blinkcount = 0;
    GameObject gameManager;
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GameObject.Find("arrow");
        renderer = GetComponent<SpriteRenderer>();

        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (getHit && manager.hp > 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                transform.Translate(-0.01f, 0, 0);
            if (Input.GetKey(KeyCode.RightArrow))
                transform.Translate(0.01f, 0, 0);
            if (Input.GetKey(KeyCode.UpArrow))
                transform.Translate(0, 0.01f, 0);
            if (Input.GetKey(KeyCode.DownArrow))
                transform.Translate(0, -0.01f, 0);
        }

        if (!getHit)
        {
            time += Time.deltaTime;
            if (time > 0.5f)
            {
                time = 0;
                GetComponent<Renderer>().enabled = isOn;
                isOn = !isOn;
                blinkcount++;
            }

            if (blinkcount > 3)
            {
                time = 0;
                isOn = false;
                blinkcount = 0;
                getHit = true;
            }
        }
    }

    public void LButtonDown()
    {
        transform.Translate(-2, 0, 0);
    }

    public void RButtonDown()
    {
        transform.Translate(2, 0, 0);
    }
}
