using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCntrl : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float playerSpeed;
    public float jumpPower;
    public int directionInput;
    public bool groundCheck;
    public bool facingRight = true;
    public float spawnX, spawnY;
    public Text pointsText;
    public int score=0;

    //находится ли персонаж на земле или в прыжке?
    private bool isGrounded = false;
    //ссылка на компонент Transform объекта
    //для определения соприкосновения с землей
    public Transform groundCheck1;
    //радиус определения соприкосновения с землей
    private float groundRadius = 0.2f;
    //ссылка на слой, представляющий землю
    public LayerMask whatIsGround;

    public Transform batutCheck;
    public bool isBatut = false;
    public LayerMask whatIsBatut;

    //public Vector3 target_move;

    //helths
    public int health;
    public int lives;
    public Image[] ilives;
    public Sprite fullLive;
    public Sprite emptyLive;

    //fire
    public Transform FirePoint;
    public GameObject bullet;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spawnX = transform.position.x;
        spawnY = transform.position.y;
        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health");
        }
    }


    void Update()   
    {   /*
        float moveX = Input.GetAxis("Horizontal");
        rb2d.MovePosition(rb2d.position+Vector2.right*moveX*playerSpeed*Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space)) {
            rb2d.AddForce(Vector2.up * 8000);
        }
        */
        //transform.Translate(target_move * playerSpeed * Time.deltaTime);

        if ((directionInput < 0) && (facingRight))
        {
            Flip();
        }

        if ((directionInput > 0) && (!facingRight))
        {
            Flip();
        }
        groundCheck = true;
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, whatIsGround);

        isBatut = Physics2D.OverlapCircle(groundCheck1.position, groundRadius, whatIsBatut);

        pointsText.text = "" + score;

        for (int i = 0; i < ilives.Length; i++)
        {
            if (i < health)
            {
                ilives[i].sprite = fullLive;
            }
            else
            {
                ilives[i].sprite = emptyLive;
            }

            if (i < lives)
            {
                ilives[i].enabled = true;
            }
            else
            {
                ilives[i].enabled = false;
            }
        }

        if (health == 0)
        {
            SceneManager.LoadScene("gameOver");
        }

        if (!isBatut)
            return;

        if (!isGrounded)
            return;
    }

    public void Move(int InputAxis)
    {

        directionInput = InputAxis;

    }

    public void Jump(bool isJump)
    {
        isJump = groundCheck;

        if (isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        /*Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;*/
        transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name) {
            case "death":
                health--;
                transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            break;

            case "tarakan":
                health--;
                transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            break;

            case "batut":
                if (isBatut)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x, 25);
                }
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.name)
        {
            case "ogurec":
                Destroy(col.gameObject);
                score++;
            break;

            case "flag":
                SceneManager.LoadScene("Level2");
            break;
        }
    }

    public void RefreshLevel() {
        PlayerPrefs.DeleteKey("health");
        SceneManager.LoadScene("firstLevel");
    }

    public void BactToMenu()
    {
        PlayerPrefs.SetInt("health", health);
        SceneManager.LoadScene("main");
    }

    public void Shoot() {
        Instantiate(bullet,FirePoint.position,FirePoint.rotation);
    }

    /*void OnGUI()
    {
        GUI.Box(new Rect(0,0,100,100), "Огурец: " + score); 
    }*/
}