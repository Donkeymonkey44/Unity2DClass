using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Animator animator;
    float jumpForce = 680f;
    float walkForce = 30f;
    float maxwalkSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && rigidbody2D.velocity.y == 0)
        {
            rigidbody2D.AddForce(transform.up * jumpForce);
        }

        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        float speedx = Mathf.Abs(rigidbody2D.velocity.x);

        if (speedx < maxwalkSpeed)
            rigidbody2D.AddForce(transform.right * key * walkForce);

        if (key != 0)
            transform.localScale = new Vector3(key, 1, 1);

        animator.speed = speedx / 2.0f ;

        if (transform.position.y < -10)
            SceneManager.LoadScene("Jumping");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ON");
        SceneManager.LoadScene("ClearScene");
    }
}
