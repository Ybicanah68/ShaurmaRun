using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.EventSystems;

public class CPlayer : MonoBehaviour
{
    public Rigidbody2D rb2d; //игрок
    /*передвжиние*/
    public float playerSpeed; //скорость перемещения
    public int directionInput; //направление движения
    public bool facingRight = true; //куда смотрит игрок
    public bool move = false; //двигается ли игрок
    /*передвижения*/

    /*счёт*/
    public Text pointsText;
    public int score = 0;
    /*счёт*/

    /*прыжок*/
    public float jumpPower; //сила прыжка
    private bool isGrounded = false; //находится ли персонаж на земле или в прыжке?
    public Transform groundCheck; //ссылка на компонент Transform объекта для определения соприкосновения с землей
    private float groundRadius = 0.2f; //радиус определения соприкосновения с землей
    public LayerMask whatIsGround; //ссылка на слой, представляющий землю
    /*прыжок*/

    /*жизни*/
    public int health;
    public int lives;
    public Image[] ilives;
    public Sprite fullLive;
    public Sprite emptyLive;
    public float spawnX, spawnY;
    /*жизни*/

    /*стрельба*/
    public Transform FirePoint;
    public GameObject bullet;
    /*стрельба*/

    /*уровни*/
    public int level;
    public int newlevel;
    public string sname;
    public string lsnumber;
    /*уровни*/

    /*меню*/
    public GameObject openmenu;
    public GameObject gameover;
    public GameObject levelmenu;
    public GameObject startlevel;
    public Transform MenuPoint;
    public bool joys=true;
    /*меню*/

    // Start is called before the first frame update
    void Start()
    {
        Destroy(Instantiate(startlevel, MenuPoint.position, MenuPoint.rotation), 2f);
        rb2d = GetComponent<Rigidbody2D>();

        spawnX = transform.position.x;
        spawnY = transform.position.y;

        sname = SceneManager.GetActiveScene().name;
        lsnumber = ((sname).Replace("Level", ""));
        level = Int32.Parse(lsnumber);

        if (PlayerPrefs.HasKey("health"))
        {
            health = PlayerPrefs.GetInt("health");
        }
    }
    // Update is called once per frame
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
    }
    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(playerSpeed * directionInput, rb2d.velocity.y);

        pointsText.text = "" + score;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        if (!isGrounded)
            return;
    }
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    public void Jump()
    {
        move = true;

        if (isGrounded)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpPower);
            move = true;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "ogurec":
                Destroy(col.gameObject);
                score++;
            break;

            case "flag":
                joys = false;
                Instantiate(levelmenu, MenuPoint.position, MenuPoint.rotation);
            break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        switch (col.gameObject.tag)
        {
            case "death":
                health--;
                if (health == 0)
                {
                    joys = false;
                    Instantiate(gameover, MenuPoint.position, MenuPoint.rotation);
                }
                transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            break;

            case "tarakan":
                health--;
                if (health == 0)
                {
                    joys = false;
                    Instantiate(gameover, MenuPoint.position, MenuPoint.rotation);
                }
                transform.position = new Vector3(spawnX, spawnY, transform.position.z);
            break;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform" && !move)
        {
            transform.SetParent(collision.transform);
        }
        else
        {
            transform.SetParent(null);
        }
    }
    public void Shoot()
    {
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }
    public void OpenMenu()
    {
        Instantiate(openmenu, MenuPoint.position, MenuPoint.rotation);
    }
}
