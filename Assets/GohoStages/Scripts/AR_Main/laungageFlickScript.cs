using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laungageFlickScript : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;

    [Header("言語を変換するスクリプトがアタッチされているゲームオブジェクト")]
    public GameObject LaungageBox;

    [Header("言語を決めた後のSE")]
    AudioSource audioSource2;
    public AudioClip sound_laungage;

    float laungagevolume = 0.2f;

    private void Start()
    {
        audioSource2 = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (RayCastMainScript.laungageon == false)
        {
            Flick();
        }

        if (rightmode == true)
        {

            GameObject cube3 = GameObject.Find("JapaneseMode");
            GameObject cube4 = GameObject.Find("EnglishMode");
            SystemScript.japan = false;
            GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
            cube3.GetComponent<Canvas>().enabled = false;
            cube4.GetComponent<Canvas>().enabled = false;
            LaungageBox.GetComponent<RayCastMainScript>().English();
            audioSource2.volume = laungagevolume;
            audioSource2.PlayOneShot(sound_laungage);
            rightmode = false;
            RayCastMainScript.laungageon = true;
            return;


        }
        if (leftmode == true)
        {
            GameObject cube3 = GameObject.Find("JapaneseMode");
           GameObject cube4 = GameObject.Find("EnglishMode");
            SystemScript.japan = true;
            GameObject.Find("laungageon").GetComponent<Renderer>().material.color = Color.gray;
            cube3.GetComponent<Canvas>().enabled = false;
            cube4.GetComponent<Canvas>().enabled = false;
            audioSource2.volume = laungagevolume;
            audioSource2.PlayOneShot(sound_laungage);
            LaungageBox.GetComponent<RayCastMainScript>().Japanese();
            leftmode = false;
            RayCastMainScript.laungageon = true;
            return;
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

            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (30 < directionX)
                {
                    //右向きにフリック
                    rightmode = true;
                }
                else if (-30 > directionX)
                {
                    //左向きにフリック
                    leftmode = true;
                }
            }
        }

    }
}
