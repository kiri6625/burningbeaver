using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class life : MonoBehaviour
{
    public GameObject pl;
    movech movech;
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        movech = pl.GetComponent<movech>();
        rect = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rect.sizeDelta = new Vector2(movech.health * 25, 25);
    }
}
