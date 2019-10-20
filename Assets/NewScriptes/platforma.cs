using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platforma : MonoBehaviour
{
    float direction = 1;
    float maxX, minX;

    // Start is called before the first frame update
    void Start()
    {
        minX = transform.position.x;
        maxX = minX + 7;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currPos = transform.position;

        if (currPos.x >= maxX)
        {
            direction = -1;
        }
        if (currPos.x <= minX)
        {
            direction = 1;
        }

        transform.Translate(new Vector3(direction * 4f * Time.deltaTime, 0, 0));
    }
}
