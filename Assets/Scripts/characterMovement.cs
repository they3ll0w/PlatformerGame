using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine.SceneManagement;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float moveStrenghSide;
    public float jumpStrengh;
    public bool characterAlive = true;

    private float horizontal;
    private bool isFacingRight;
    public Transform groundCheck;
    public LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();

        if (Input.GetKeyDown(KeyCode.Space) && characterAlive && TouchGround())
        {
            myRigidbody.velocity = Vector2.up * jumpStrengh;
        }

        if (transform.position.y < -6)
        {
            RestartLevel();
        }
    }

    private void FixedUpdate()
    {
        myRigidbody.velocity = new Vector2(horizontal * moveStrenghSide, myRigidbody.velocity.y);
    }

    private void Flip()
    {
        if (!isFacingRight && horizontal < 0 || isFacingRight && horizontal > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }
    }

    private bool TouchGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RestartLevel();
    }
}
