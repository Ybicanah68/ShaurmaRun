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

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spawnX = transform.position.x;
        spawnY = transform.position.y;

    }


    void Update()
    {
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

        if (!isBatut)
            return;

        if (!isGrounded)
            return;
        pointsText.text = "" + score;
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
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.name) {
            case "death":
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
        if (col.gameObject.name == "ogurec") {
            Destroy(col.gameObject);
            score++;
        }
    }

    public void RefreshLevel() {
        SceneManager.LoadScene("firstLevel");
    }

    public void BactToMenu()
    {
        SceneManager.LoadScene("main");
    }

    /*void OnGUI()
    {
        GUI.Box(new Rect(0,0,100,100), "Огурец: " + score); 
    }*/
}