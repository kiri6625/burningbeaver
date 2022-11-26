using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveca : MonoBehaviour
{
    public GameObject player;
    float y;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= 1)
        {
            y = 4;
        }
        else
        {
            y = player.transform.position.y + 3;
        }
        gameObject.transform.position = new Vector3(player.transform.position.x + 5, y, -9);
    }
}
