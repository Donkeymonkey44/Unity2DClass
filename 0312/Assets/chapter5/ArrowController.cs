using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    GameObject gameManager;
    GameManager manager;
    CatController catController;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        catController = player.GetComponent<CatController>();

        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.05f, 0);

        if (transform.position.y < -5.0f)
            Destroy(gameObject);

        // 충돌 판정
        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 dir = p1 - p2;

        float d = dir.magnitude;

        float r1 = 0.5f;
        float r2 = 1.0f;

        if (d < r1 + r2) // 충돌 된 경우
        {
            manager.DecreaseHP();
            Destroy(gameObject);
            catController.getHit = false;
        }
    }
}
