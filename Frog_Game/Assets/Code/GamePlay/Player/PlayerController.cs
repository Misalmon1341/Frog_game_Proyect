using System;
using System.Collections;
using Dino.Utility.Audio;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region KeyBoardInputs
    
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
            AudioManager.Instance.PlaySound("jumpsound");
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {   
            AudioManager.Instance.PlaySound("crouchsound");
        }   
    }
    
    #endregion
    /*
     private Rigidbody2D rb;
    public float jumpforce;
    private bool isGrounded;
    private Animator playerAnimator;
    public int maxHealth;
    public int coinValue;
    private int currentHealth;
    private GamePlayUi gamePlayUi;
    
    private InputAction touchPressAction;
    private InputAction touchPositionAction;
    private Vector2 touchStartPos;
    private float swipeThreshold = 80f;
    private bool isCrouching = false;

    void Awake()
    {
        touchPressAction   = new InputAction("TouchPress",   binding: "<Touchscreen>/primaryTouch/press");
        touchPositionAction = new InputAction("TouchPosition", binding: "<Touchscreen>/primaryTouch/position");
    }

    void OnEnable()
    {
        touchPressAction.Enable();
        touchPositionAction.Enable();

        // Dedo toca la pantalla
        touchPressAction.started  += OnTouchStarted;
        // Dedo se levanta
        touchPressAction.canceled += OnTouchCanceled;
    }

    void OnDisable()
    {
        touchPressAction.started  -= OnTouchStarted;
        touchPressAction.canceled -= OnTouchCanceled;

        touchPressAction.Disable();
        touchPositionAction.Disable();
    }

    void OnDestroy()
    {
        touchPressAction.Dispose();
        touchPositionAction.Dispose();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        gamePlayUi = UiManager.Instance.GetWindow(WindowsIds.GameplayUI) as GamePlayUi;
    }

    // ─────────────────────────────────────────
    //  CALLBACKS DE TOUCH
    // ─────────────────────────────────────────

    private void OnTouchStarted(InputAction.CallbackContext ctx)
    {
        // Guardamos dónde empezó el toque
        touchStartPos = touchPositionAction.ReadValue<Vector2>();
    }

    private void OnTouchCanceled(InputAction.CallbackContext ctx)
    {
        // El dedo se levantó → calculamos el swipe
        Vector2 touchEndPos = touchPositionAction.ReadValue<Vector2>();
        Vector2 swipeDelta  = touchEndPos - touchStartPos;

        // Ignoramos si el movimiento es principalmente horizontal
        if (Mathf.Abs(swipeDelta.y) < swipeThreshold) return;
        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)) return;

        if (swipeDelta.y > 0)
        {
            // ↑ Swipe arriba → saltar
            PerformJump();
        }
        else
        {
            // ↓ Swipe abajo → agacharse un instante y luego levantarse
            PerformCrouch();
            // Nos levantamos en el siguiente frame con una corrutina
            StartCoroutine(StandUpAfterDelay(0.5f));
        }

        if (isCrouching)
            EndCrouch();
    }

    // ─────────────────────────────────────────
    //  ACCIONES
    // ─────────────────────────────────────────

    private void PerformJump()
    {
        if (!isGrounded) return;

        AudioManager.Instance.PlaySound("jumpsound");
        playerAnimator.SetBool("Run",  false);
        playerAnimator.SetBool("Jump", true);
        rb.AddForce(Vector2.up * jumpforce);
        Debug.Log("Saltando");
    }

    private void PerformCrouch()
    {
        if (!isGrounded || isCrouching) return;

        isCrouching = true;
        playerAnimator.SetBool("Run",    false);
        playerAnimator.SetBool("Crouch", true);
        AudioManager.Instance.PlaySound("crouchsound");
        Debug.Log("Agachado");
    }

    private void EndCrouch()
    {
        if (!isCrouching) return;

        isCrouching = false;
        playerAnimator.SetBool("Crouch", false);
    }

    private System.Collections.IEnumerator StandUpAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        EndCrouch();
    }

    // ─────────────────────────────────────────
    //  UPDATE — solo animación de correr
    // ─────────────────────────────────────────
    void Update()
    {
#if UNITY_EDITOR
        if (Mouse.current.leftButton.wasPressedThisFrame)
            PerformJump();
        if (Mouse.current.rightButton.wasPressedThisFrame)
            PerformCrouch();
#endif
    
        // Touch real para el dispositivo
#if !UNITY_EDITOR
    HandleTouchInput();
#endif
        if (isGrounded && !isCrouching)
            playerAnimator.SetBool("Run", true);
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
            playerAnimator.SetBool("Run",  false);
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
    */
}
