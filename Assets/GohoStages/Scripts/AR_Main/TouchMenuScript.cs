using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMenuScript : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;
    bool upmode = false;
    bool downmode = false;
    float timer = 0;
    float DirectionXmove = 0;
    float DirectionYmove = 0;

    private int count = 0;
    float speed = 0.0025f;

    //位置データ取得用  
    /*static public float positionx = 0;
    static public float positiony = 0;
    static public float positionz = 0;*/



    private void Update()
    {
        if (RayCastMainScript.texton1 == true)
        { if (RayCastMainScript.worksmode == false) {
                if (RayCastMainScript.laungageon == true)
                {
                    Flick();
                    /*positionx = this.transform.position.x;
                    positiony = this.transform.position.y;
                    positionz = this.transform.position.z;*/
                }
            }
        }

        if (rightmode == true)
        {
            if (this.transform.position.x < 0.381f)
            {
                timer += Time.deltaTime;
                if (timer < 0.19f)
                {
                    this.transform.position += new Vector3(DirectionXmove * Time.deltaTime * speed, 0, 0);

                }
                if (timer > 0.2f)
                {
                    rightmode = false;
                    timer = 0;
                }
            }

        }
        if (leftmode == true)
        {
            if (this.transform.position.x >-0.379f)
            {
                timer += Time.deltaTime;
                if (timer < 0.19f)
                {
                    this.transform.position += new Vector3(DirectionXmove * Time.deltaTime * speed, 0, 0);
                }
                if (timer > 0.2f)
                {
                    leftmode = false;
                    timer = 0;
                }
            }
        }

        if (upmode == true)
        {
            if (this.transform.position.y < 0.235f)
            {
                timer += Time.deltaTime;
                if (timer < 0.19f)
                {

                    this.transform.position += new Vector3(0, DirectionYmove * Time.deltaTime * speed, 0);
                }
                if (timer > 0.2f)
                {
                    upmode = false;
                    timer = 0;
                }
            }
        }

        if (downmode == true)
        {
            if (this.transform.position.y > -0.384f)
            {
                timer += Time.deltaTime;
                if (timer < 0.19f)
                {
                    this.transform.position += new Vector3(0, DirectionYmove * Time.deltaTime * speed, 0);
                }
                if (timer > 0.2f)
                {
                    downmode = false;
                    timer = 0;
                }
            }
        }

    }
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x,
                                        Input.mousePosition.y,
                                        Input.mousePosition.z);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x,
                                      Input.mousePosition.y,
                                      Input.mousePosition.z);
            GetDirection();
        }
    }

    void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        //string Direction;



        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック

                DirectionXmove = directionX;
                rightmode = true;
            }
            else if (-30 > directionX)
            {
                //左向きにフリック

                DirectionXmove = directionX;
                leftmode = true;
            }
            if(count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi_1");
                cube2.GetComponent<Canvas>().enabled = false;
                count++;
            }
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                DirectionYmove = directionY;
                upmode = true;

            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                DirectionYmove = directionY;
                downmode = true;
            }
            if (count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi_1");
                cube2.GetComponent<Canvas>().enabled = false;
                count++;
            }
        }
        else
        {
            //タッチを検出
        }

    }
}
