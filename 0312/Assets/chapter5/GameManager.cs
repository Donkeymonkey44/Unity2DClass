using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    GameObject hpGauage;
    GameObject score;
    TMP_Text scoreText;
    float time;
    int dTime = 0;
    public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        hpGauage = GameObject.Find("hpGauage");
        score = GameObject.Find("Score");

        scoreText = score.GetComponent<TMP_Text>();
    }

    public void DecreaseHP()
    {
        hpGauage.GetComponent<Image>().fillAmount -= 0.1f;
        hp--;
    }

    private void Update()
    {
        if (hp > 0)
        {
            time += Time.deltaTime;
            if (time > 1)
            {
                dTime++;
                time = 0;
            }

            scoreText.text = "Score : " + dTime.ToString();
        }
        if (hp == 0)
            scoreText.text = "Scoreline is " + dTime.ToString();
    }
}
