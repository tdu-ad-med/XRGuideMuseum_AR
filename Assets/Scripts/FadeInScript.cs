using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeInScript : MonoBehaviour
{
    float timer = 0;


    public float speed = 0.01f;  //透明化の速さ
    float alfa;    //A値を操作するための変数
    float red, green, blue;    //RGBを操作するための変数

   

    // Start is called before the first frame update
    void Start()
    {
      
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        alfa = GetComponent<Image>().color.a;
    }

    // Update is called once per frame
    void Update()
    {

            timer += Time.deltaTime;
            if (timer > 2)
            {
                GetComponent<Image>().color = new Color(red, green, blue, alfa);
                alfa += speed;
            }
            if (timer > 5)
            {
                SceneManager.LoadScene("AR_Sample2");
            }
        
        
    }

}
