using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpforce;
    private bool isGrounded;
    private Animator playerAnimator;
    public int maxHealth;
    private int currentHealth;
    private GamePlayUi gamePlayUi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gamePlayUi = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            playerAnimator.SetBool("Jump", false);
        }
       
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Golpeo al juagdor");
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Hurt", true);
            GameManager.Instance.LostHearts();
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            bool heartRetrieve = GameManager.Instance.WinHearts();
            if (heartRetrieve)
            {
             Destroy(other.gameObject);
            }
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Salio del juagdor");
            playerAnimator.SetBool("Hurt", false);
        }
        
        
    }

    void Update()
    {
        Jump();
        Crouch();
        
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerAnimator.SetBool("Run", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", true);
            rb.AddForce(Vector2.up * jumpforce);
            Debug.Log("Saltando");
        }
    }
    public void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Crouch", true);
            Debug.Log("Agachado");
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) && isGrounded)
        {
            playerAnimator.SetBool("Crouch", false);
        }
        
    }

   
    
}
