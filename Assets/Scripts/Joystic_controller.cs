using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystic_controller : MonoBehaviour
{

    public GameObject touch_marker;
    Vector3 target_vector;
    public PlayerCntrl sg_controller;

    // Start is called before the first frame update
    void Start()
    {
        touch_marker.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButton(0))
        //if (Input.touchCount > 0)
        {
            Vector3 touch_pos = Input.mousePosition;
            //Vector3 touch_pos = Input.GetTouch(0).position;
            target_vector = touch_pos - transform.position;

            if (target_vector.magnitude < 100)
            {
                touch_marker.transform.position = touch_pos;
                //sg_controller.target_move = new Vector3(target_vector.x, 0,0);
                if (target_vector.x < 0)
                {
                    sg_controller.directionInput = -1;
                }
                else
                {
                    sg_controller.directionInput = 1;
                }
            }
        }
        else
        {
            touch_marker.transform.position = transform.position;
            sg_controller.directionInput = 0;
        }
    }
}
