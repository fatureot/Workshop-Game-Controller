using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D Rb;
    public float jumpForce;
    float score = 0f;
    //variable start position
    private Vector3 startPos;

    public Text scoreTxt;
    void Start()
    {
        startPos = transform.position;
        Rb = GetComponent<Rigidbody2D>();
    }
    
    public void ResetPlayer()
    {
        transform.position = startPos;
        Rb.linearVelocity = Vector2.zero;
        score = 0;
    }

    void Update()
    {
        if (GameManager.instance.isGameStarted == false)
        {
            return;
        }
        
        switch (ControllerConfigManager.instance.GetControllerType())
        {
            case ControllerType.Keyboard:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Rb.linearVelocity = Vector2.up * jumpForce;
                }
                break;
            case ControllerType.Mouse:
                if (Input.GetMouseButtonDown(0))
                {
                    Rb.linearVelocity = Vector2.up * jumpForce;
                }
                break;
            default:
                break;
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
