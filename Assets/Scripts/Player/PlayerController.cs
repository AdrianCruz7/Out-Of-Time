using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerDamage = 10;
    public float moveSpeed;
    public float playerTime;
    PlayerInputs inputActions;
    Rigidbody2D rb;
    Vector2 playerMovement;

    bool playerIsRolling = false;
    float playerRollSpeed = 30f;
    float playerRollDuration = 0.2f;
    float playerRollCooldown = 5f;

    Vector2 playerRollDirection;
    float playerRollDurationTime;
    float playerRollCooldownTime;

    public List<BaseItemScript> playerItems = new List<BaseItemScript>();

    private Animator playerAnimator;

    public event Action OnDamage;

    private GunslingerActiveItem activeItem;

    void Awake()
    {
        playerDamage = 10;
        inputActions = new PlayerInputs();
        rb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        activeItem = GetComponent<GunslingerActiveItem>();
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
        InputManager.Instance.OnActivateItem += ActivateItem;
    }

    void Update()
    {
        Countdown();
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(playerMovement.x, playerMovement.y);

        if(playerMovement.x != 0 || playerMovement.y != 0) 
        {
            playerAnimator.SetFloat("X", playerMovement.x);
            playerAnimator.SetFloat("Y", playerMovement.y);
            playerAnimator.SetBool("IsWalking", true);
        }
        else
        {
            playerAnimator.SetBool("IsWalking", false);
        }

        if (playerIsRolling && playerRollCooldownTime < 0)
        {
            rb.MovePosition(rb.position + playerRollDirection * playerRollSpeed * Time.fixedDeltaTime);

            if(Time.time > playerRollDurationTime)
            {
                playerIsRolling = false;
                playerRollCooldownTime = playerRollCooldown;
            }
        }
        else
        {
            playerRollCooldownTime -= Time.deltaTime;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void ReadPlayerMovement(Vector2 context)
    {
        playerMovement = context;
    }

    void Countdown()
    {
        if (playerTime > 0 && playerItems.Exists(x => x.itemID == 1))
        {
            //Debug.Log("Amulet exists");
            playerTime -= Time.deltaTime * 0.75f;
            return;
        }

        if (playerTime > 0)
        {
            //Debug.Log("Amulet does not exists");
            playerTime -= Time.deltaTime;
        }
        else Death();
    }
    
    void Death()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void StartRoll()
    {
        playerIsRolling = true;
        playerRollDirection = playerMovement.normalized;
        playerRollDurationTime = Time.time + playerRollDuration;
    }

    public void Damage(float damage)
    {
        playerTime -= damage;
        OnDamage?.Invoke();
    }

    void ActivateItem()
    {
        Debug.Log("Item Activated");
        activeItem.ActivateItem();
    }

    public float GetPlayerDamage()
    {
        return playerDamage;
    }
}
