using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Player : Entity
{
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource coinsSound;
    [SerializeField] private AudioSource anemuSound;


    [SerializeField] private float speed =3f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private int health;
   

    [SerializeField] private Image[] hearts;
    [SerializeField] private Sprite aliveHeart;
    [SerializeField] private Sprite deadHeart;

    [SerializeField] GameObject GameOverScreen;

    private bool isGrounded; 
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public Joystick joystick;
   
    public static Player Instance { get; set; }


    public int score;
    //public Text scoreText;


    private State state
    {
        get { return (State)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    private void Awake()
    {
        lives = 3;
        health = lives;
        Instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponent<Animator>();

       if (PlayerPrefs.HasKey("SaveCoint"))
          score = PlayerPrefs.GetInt("SaveCoint"); 
       
    }

    private void FixedUpdate()
    {
        CheckGround();
    }


    private void Update()
    {
       if (isGrounded) state = State.idlePlayer;

        if (joystick.Horizontal !=0)
            Run();

        if (joystick.Vertical >0.5f && isGrounded)
        {
            Jump();
        }

        if (transform.position.y < -10f)
        {
            Die();
            GameOverScreen.SetActive(true);
        }

        if (health > lives)
            health = lives;
        for (int i=0; i<hearts.Length; i++)
        {
            if (i < health)
                hearts[i].sprite = aliveHeart;
            else hearts[i].sprite = deadHeart;

            if (i < lives)
                hearts[i].enabled = true;
            else hearts[i].enabled = false;

        }

       
    }
    private void Run()
    {

      if (isGrounded == true) state = State.runPlayer;

        Vector3 dir = transform.right * joystick.Horizontal;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, speed * Time.deltaTime);

        spriteRenderer.flipX = dir.x < 0.0f;

        
    }

    private void Jump()
    {

        rigidbody2D.velocity = Vector2.up * jumpForce;
        jumpSound.Play();

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

    public void AddCoid(int count)
    {
        score += count;
        PlayerPrefs.SetInt("SaveCoint", score);
        // scoreText.text = score.ToString();
        coinsSound.Play();
    }

    public override void GetDamage()
    {
        health -= 1;
        anemuSound.Play();
        if (health ==0)
        {
            foreach (var h in hearts)
                h.sprite = deadHeart;
            Die();
            GameOverScreen.SetActive(true);
        }
    }



}
