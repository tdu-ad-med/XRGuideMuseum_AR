using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingScript : MonoBehaviour
{

    static public float alfa;
    float red, green, blue;    //RGBを操作するための変数
    float speed = 2.0f;
    float center = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
        alfa = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa = Mathf.Cos(speed*Time.time+Mathf.PI)/2  + center;
        
    }


}
