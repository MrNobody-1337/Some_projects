using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private Rigidbody2D rigidBodyPlayer;
    private Vector3 startingPosition;

    public LayerMask groundLayer;
    public Animator animatorPlayer;
    public float jumpForce = 25f;
    public float runningSpeed = 2.5f;
    public static PlayerController instancePlayer;
        
    
    private void Awake()
    {
        rigidBodyPlayer = GetComponent<Rigidbody2D>();
        instancePlayer = this;
        startingPosition = this.transform.position;
    }

    public void StartGame()
    {
        animatorPlayer.SetBool("isAlive", true);
        this.transform.position = startingPosition;
    }

    private bool IsGrounded()
    {
        if(Physics2D.Raycast(this.transform.position, Vector2.down, 0.2f, groundLayer.value))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rigidBodyPlayer.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.instance.currentGameState == GameState.inGame)
        {
            rigidBodyPlayer.WakeUp();
            if (rigidBodyPlayer.velocity.x < runningSpeed)
            {
                rigidBodyPlayer.velocity = new Vector2(runningSpeed, rigidBodyPlayer.velocity.y);
            }
        }
        else
        {
            rigidBodyPlayer.Sleep();
        }
    }

    void Update() { 
    
        if(GameManager.instance.currentGameState == GameState.inGame)
        {
             if (Input.GetMouseButtonDown(0)||Input.GetButtonDown("Jump"))
             {
                Jump();
                Debug.Log("Left mouse button's been clicked!");
             }
             else if (Input.GetButtonDown("Cancel"))
             {

             }       
            animatorPlayer.SetBool("isGrounded", IsGrounded());
        }
    }

    public void Kill()
    {
        GameManager.instance.GameOver();
        animatorPlayer.SetBool("isAlive", false);
        
        if(PlayerPrefs.GetFloat("highscore", 0) < this.GetDistance())
        {
            PlayerPrefs.SetFloat("highscore", this.GetDistance());
        }
    }

    public float GetDistance()
    {
        float traveledDistance = Vector2.Distance(new Vector2(startingPosition.x, 0), new Vector2(this.transform.position.x, 0));
        return traveledDistance;
    }
}
