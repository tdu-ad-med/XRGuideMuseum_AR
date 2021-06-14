using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchTextScript : MonoBehaviour
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
    float speed = 0.0025f;

    Vector3 rightpos;

    static public int count = 0;//フリックするといった示唆をしているアイコンを一回表示にするために使うもの

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            if (RayCastMainScript.texton1 == false && RayCastMainScript.laungageon == true && RayCastMainScript.worksmode == false)
            {
                Flick();
            }
        }
        if (SceneManager.GetActiveScene().name == "AR_Main2")
        {
            if (RayCastScript2.texton2 == false && RayCastScript2.laungageon2 == true && RayCastScript2.worksmode2 == false)
            {
                Flick();
            }
        }

        if (rightmode == true)
        {
            if (this.transform.position.x < 0.3f)
            {
                timer += Time.deltaTime;
                if (timer < 0.1f)
                {

                    this.transform.position += new Vector3(DirectionXmove * Time.deltaTime * speed, 0, 0);
                }
                if (timer > 0.11f)
                {
                    rightmode = false;
                    timer = 0;
                }
            }

            if (count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi");
                cube2.GetComponent<Canvas>().enabled = false;


                count++;
            }
        }
        if (leftmode == true)
        {
            if (this.transform.position.x > -0.36f)
            {
                timer += Time.deltaTime;
                if (timer < 0.1f)
                {
                    this.transform.position += new Vector3(DirectionXmove * Time.deltaTime * speed, 0, 0);
                }
                if (timer > 0.11f)
                {
                    leftmode = false;
                    timer = 0;
                }
            }

            if (count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi");
                cube2.GetComponent<Canvas>().enabled = false;
                

                count++;
            }
        }

        if (upmode == true)
        {
            if (this.transform.position.y < 0.04f)
            {
                timer += Time.deltaTime;
                if (timer < 0.1f)
                {

                    this.transform.position += new Vector3(0, DirectionYmove * Time.deltaTime * speed, 0);
                }
                if (timer > 0.11f)
                {
                    upmode = false;
                    timer = 0;
                }
            }
            
            if (count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi");
                cube2.GetComponent<Canvas>().enabled = false;


                count++;
            }
        }

        if (downmode == true)
        {
            if (this.transform.position.y > -0.3f)
            {
                timer += Time.deltaTime;
                if (timer < 0.1f)
                {
                    this.transform.position += new Vector3(0, DirectionYmove * Time.deltaTime * speed, 0);
                }
                if (timer > 0.11f)
                {
                    downmode = false;
                    timer = 0;
                }
            }
            
            if (count == 0)
            {
                GameObject cube2 = GameObject.Find("Navi");
                cube2.GetComponent<Canvas>().enabled = false;


                count++;
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
        }
        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY) {
                //上向きにフリック
                DirectionYmove = directionY;
                upmode = true;

            } else if (-30 > directionY)
            {
                //下向きのフリック
                DirectionYmove = directionY;
                downmode = true;
            }
        } else
        {
            //タッチを検出
         
            
        }

    }
}

