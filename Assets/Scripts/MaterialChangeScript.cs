using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChangeScript : MonoBehaviour
{
    public Material[] _material;           // 割り当てるマテリアル.
    static public int i;


    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;

    public GameObject LaungageBox;


    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (RayCastMainScript.worksmode == true)
        {
            Flick();
        }

        if (rightmode == true)
        {
            
            if (i == 3)
            {
                i = -1;
            }
            
            i++;
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            LogSystemScript.GimicLog++;
            if (SystemScript.japan == true)
            {
                LaungageBox.GetComponent<RayCastMainScript>().Japanese();

            }
            if (SystemScript.japan == false)
            {
                LaungageBox.GetComponent<RayCastMainScript>().English();

            }
            rightmode = false;



        }
        if (leftmode == true)
        {
            
            if (i == 0)
            {
                i = 3;
            }
            
            i--;
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            LogSystemScript.GimicLog++;
            if (SystemScript.japan == true)
            {
                LaungageBox.GetComponent<RayCastMainScript>().Japanese();

            }
            if (SystemScript.japan == false)
            {
                LaungageBox.GetComponent<RayCastMainScript>().English();

            }
            leftmode = false;



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

                    //DirectionXmove = directionX;
                    rightmode = true;
                }
                else if (-30 > directionX)
                {
                    //左向きにフリック

                    //DirectionXmove = directionX;
                    leftmode = true;
                }
            }
            else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {

            }
            else
            {
                //タッチを検出


            }



        }

    }
}
