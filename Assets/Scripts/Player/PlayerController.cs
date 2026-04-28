using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float currentHP = 100;
    public float speed = 5f;
    public PlayerData playerData;
    private PlayerInput playerInput;
    private Vector2 moveInput;

    void Start()
    {
        currentHP = playerData.maxHP;
        speed = playerData.moveSpeed;
        playerInput = GetComponent<PlayerInput>();
    }
    
    
    void Update()
    {
        if (playerInput == null) return;
        
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        float h = moveInput.x;
        float v = moveInput.y;

        transform.Translate(new Vector3(h, v, 0) * speed * Time.deltaTime);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            TakeDamage(1f);
        }
    }

    void TakeDamage(float dmg)
    {   
        if (currentHP != 0)
        {
            currentHP -= dmg;
            Debug.Log("Player HP: " + currentHP);
        }
        
        else if (currentHP <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}