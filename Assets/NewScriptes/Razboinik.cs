using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Razboinik : MonoBehaviour
{
    float direction = 1;
    float maxX, minX;
    public bool facingRight = false;

    public int health=3;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x;
        maxX = minX + 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.position;

        if (currPos.x >= maxX && (facingRight)) {
            direction = -1;
            Flip();
        }
        if (currPos.x <= minX && (!facingRight))
        {
            direction = 1;
            Flip();
        }

        transform.Translate(new Vector3(direction*5f*Time.deltaTime,0,0));
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void TakeDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
