using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;
	
	public SpriteRenderer spriteRenderer;
	
	public Sprite up;
	public Sprite down;
	public Sprite left;
	public Sprite right;
	
	public Transform weapon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
		weapon = transform.Find("Weapon"); // I had to look up how to find the weapon from the code since using the Inspector UI to set things felt weird to me
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {

        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
			spriteRenderer.sprite = left;
			weapon.localScale = new Vector3(-1, 1, 1);
			weapon.localEulerAngles = new Vector3(0, 0, 0);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
			spriteRenderer.sprite = right;
			weapon.localScale = new Vector3(1, 1, 1);
			weapon.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
			spriteRenderer.sprite = up;
			weapon.localScale = new Vector3(1, 1, 1);
			weapon.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
			spriteRenderer.sprite = down;
			weapon.localScale = new Vector3(1, 1, 1);
			weapon.localEulerAngles = new Vector3(0, 0, -90);
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}
