using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    public float playerTime;
    PlayerInputs inputActions;
    Rigidbody2D rb;
    Vector2 playerMovement;

    bool playerIsRolling = false;
    float playerRollSpeed = 30f;
    float playerRollDuration = 0.2f;
    float playerRollCooldown = 1f;

    Vector2 playerRollDirection;
    float playerRollDurationTime;
    float playerRollCooldownTime;


    void Awake()
    {
        inputActions = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();    
    }

    void Start()
    {
        InputManager.Instance.OnMovePerformed += ReadPlayerMovement;
        InputManager.Instance.OnMoveCancelled += ReadPlayerMovement;
        InputManager.Instance.OnRoll += StartRoll;
    }

    void Update()
    {
        Countdown();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(playerMovement.x, playerMovement.y);

        if (playerIsRolling)
        {
            rb.MovePosition(rb.position + playerRollDirection * playerRollSpeed * Time.fixedDeltaTime);

            if(Time.time > playerRollDurationTime)
            {
                playerIsRolling = false;
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void ReadPlayerMovement(Vector2 context)
    {
        playerMovement = context;
    }

    void Countdown()
    {
        if (playerTime > 0)
        {
            playerTime -= Time.deltaTime;
        }
        else Death();
    }
    
    void Death()
    {
        Debug.Log("Die");
    }

    void StartRoll()
    {
        playerIsRolling = true;
        playerRollDirection = playerMovement.normalized;
        playerRollDurationTime = Time.time + playerRollDuration;
        playerRollCooldownTime = Time.time + playerRollCooldown;
    }
}
