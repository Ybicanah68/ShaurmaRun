using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public float fireX, firenowX;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        fireX = transform.position.x;
    }

    void Update()
    {
        firenowX = Mathf.Abs(rb.position.x - fireX);
        if (firenowX > 30) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Razboinik tarakan = hitInfo.GetComponent<Razboinik>();
        if (tarakan != null) {
            tarakan.TakeDamage(1);
        }
        if (hitInfo.gameObject.name == "tarakan")
        {
            Destroy(gameObject);
        }
    }
}
