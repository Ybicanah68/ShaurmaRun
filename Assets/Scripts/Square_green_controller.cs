using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square_green_controller : MonoBehaviour
{
    public float speed;
    public Vector3 target_move;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, Screen.width), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 0, Screen.height), transform.position.z);
        transform.Translate(target_move * speed * Time.deltaTime);
    }
}
