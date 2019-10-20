using UnityEngine;

public class CamMove : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        if (player.transform.position.x > 0)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10f);
        }
        else
        {
            transform.position = new Vector3(0, player.transform.position.y, -10f);
        }

    }
}