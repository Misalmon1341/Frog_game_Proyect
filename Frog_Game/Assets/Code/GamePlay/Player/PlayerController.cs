using System;
using System.Collections;
using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
     private Rigidbody2D rb;
    public float jumpforce;
    private bool isGrounded;
    private Animator playerAnimator;
    public int maxHealth;
    public int coinValue;
    private int currentHealth;
    private GamePlayUi gamePlayUi;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gamePlayUi = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        gamePlayUi.JumpButton.onClick.AddListener(() => Jump());
        AddHoldEvents(gamePlayUi.CrouchButton.gameObject);
    }

    private void AddHoldEvents(GameObject buttonObj)
    {
        EventTrigger trigger = buttonObj.GetComponent<EventTrigger>();
        
       
        if (trigger == null)
            trigger = buttonObj.AddComponent<EventTrigger>();

        EventTrigger.Entry pointerDown = new EventTrigger.Entry();
        pointerDown.eventID = EventTriggerType.PointerDown;
        pointerDown.callback.AddListener((_) => StartCrouch());
        trigger.triggers.Add(pointerDown);

      
        EventTrigger.Entry pointerUp = new EventTrigger.Entry();
        pointerUp.eventID = EventTriggerType.PointerUp;
        pointerUp.callback.AddListener((_) => EndCrouch());
        trigger.triggers.Add(pointerUp);
    }
    
    public void Jump()
    {
        if (!isGrounded) return;

        AudioManager.Instance.PlaySound("jumpsound");
        playerAnimator.SetBool("Run", false);
        playerAnimator.SetBool("Jump", true);
        rb.AddForce(Vector2.up * jumpforce);
        Debug.Log("Saltando");
    }

    public void StartCrouch()
    {
        if (!isGrounded) return;

        AudioManager.Instance.PlaySound("crouchsound");
        playerAnimator.SetBool("Run", false);
        playerAnimator.SetBool("Crouch", true);
        Debug.Log("Agachado");
    }

    public void EndCrouch()
    {
        playerAnimator.SetBool("Crouch", false);
        Debug.Log("Levantado");
    }

    private void Run()
    {
        if (isGrounded)
            playerAnimator.SetBool("Run", true);
    }

    void Update()
    {
        Run();
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
            isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            AudioManager.Instance.PlaySound("damagesound");
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Hurt", true);
            GameManager.Instance.LostHearts();
        }
        if (other.gameObject.CompareTag("Heart"))
        {
            if (GameManager.Instance.WinHearts())
                Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            AudioManager.Instance.PlaySound("coinsound");
            GameManager.Instance.AddCoins(coinValue);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
            playerAnimator.SetBool("Hurt", false);
    }
}
    #region KeyBoardInputs
    /*
     private Rigidbody2D rb;
    public float jumpforce;
    private bool isGrounded;
    private Animator playerAnimator;
    public int maxHealth;
    public int coinValue;
    private int currentHealth;
    private GamePlayUi gamePlayUi;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gamePlayUi = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
        gamePlayUi.JumpButton.onClick.AddListener(() => Jump());
        gamePlayUi.CrouchButton.onClick.AddListener(() => Crouch());
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
            AudioManager.Instance.PlaySound("damagesound");
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
            AudioManager.Instance.PlaySound("coinsound");
            GameManager.Instance.AddCoins(coinValue);
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
       //Jump();
        //Crouch();
        Run();
    }

    private void Run()
    {
        if (isGrounded)
        {
            playerAnimator.SetBool("Run", true);
        }
    }

    public void Jump()
    {
        if (isGrounded)
        {
            gamePlayUi.JumpButton.onClick.RemoveAllListeners();
            AudioManager.Instance.PlaySound("jumpsound");
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Jump", true);
            rb.AddForce(Vector2.up * jumpforce);
            Debug.Log("Saltando");
            gamePlayUi.JumpButton.onClick.AddListener(() => Jump());
        }
    }
    public void Crouch()
    {
        
        if (isGrounded)
        {
            AudioManager.Instance.PlaySound("crouchsound");
            gamePlayUi.CrouchButton.onClick.RemoveAllListeners();
            playerAnimator.SetBool("Run", false);
            playerAnimator.SetBool("Crouch", true);
            Debug.Log("Agachado");
            gamePlayUi.CrouchButton.onClick.AddListener(() => Crouch());
        }
        
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {   
            AudioManager.Instance.PlaySound("crouchsound");
        }
    
    }
    */

    
    
    #endregion
