using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject ArrowPrefab;
    float spawn = 1.0f;
    float delta = 0;
    GameObject gameManager;
    GameManager manager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        manager = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.hp > 0)
        {
            delta += Time.deltaTime;
            if (delta > spawn)
            {
                delta = 0;
                GameObject go = Instantiate(ArrowPrefab);

                int px = Random.Range(-6, 7);
                go.transform.position = new Vector3(px, 7, 0);
            }
        }
    }
}
