using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float jumpForce;
    float score = 0f;

    public Text scoreTxt;
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Rb.linearVelocity = Vector2.up * jumpForce;
        }

        scoreTxt.text = "" + score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="point")
        {
            score++;
        }
        if (collision.gameObject.tag == "Pipa")
        {
            Destroy(gameObject);
        }

    }
}
