using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private float speed =3f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int lives = 5;

    private bool isGrounded; 
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

   
    public static Player Instance { get; set; }


    //public int score;
    //public Text scoreText;


    private State state
    {
        get { return (State)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();
       
    }

    private void FixedUpdate()
    {
        CheckGround();
    }


    private void Update()
    {
       if (isGrounded) state = State.idlePlayer;

        if (Input.GetButton("Horizontal"))
            Run();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    private void Run()
    {

      if (isGrounded == true) state = State.runPlayer;

        Vector3 dir = transform.right * Input.GetAxis("Horizontal");

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        spriteRenderer.flipX = dir.x < 0.0f;

     
       
    }

    private void Jump()
    {

        rigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);


    }

    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        isGrounded = collider.Length > 1;

       if (!isGrounded) state = State.jumpPlayer;
    }

    public enum State
    {
        idlePlayer,
        runPlayer,
        jumpPlayer,
        climbPlayer     
        
           }

    //public void AddCoid(int count)
    //{
    //    score += count;
    //    scoreText.text = score.ToString();
    //}

    



}
