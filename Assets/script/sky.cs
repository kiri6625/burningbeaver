using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sky : MonoBehaviour
{
    public GameObject maincamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x - maincamera.transform.position.x <= -25)
        {
            gameObject.transform.Translate(56, 0, 0);
        }
    }
}
