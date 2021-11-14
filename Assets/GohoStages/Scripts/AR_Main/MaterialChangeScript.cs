using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MaterialChangeScript : MonoBehaviour
{
    [Header("絵画の数及びマテリアル素材")]
    public Material[] _material;           // 割り当てるマテリアルの数
    static public int i;


    private Vector3 touchStartPos;
    private Vector3 touchEndPos;
    bool rightmode = false;
    bool leftmode = false;
    int count = 1;
    int count_1 = 1;

    //[Header("言語を変換するスクリプトがアタッチされているゲームオブジェクト")]
    //public GameObject LaungageBox;
    //public GameObject LaungageBox2;

    // Use this for initialization
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "AR_Main")
        {
            if (RayCastMainScript.laungageon == true && RayCastMainScript.texton1 == true && RayCastMainScript.worksmode == true)
            {
                Flick();
                if (count_1 == 1)
                {
                    GameObject cube7 = GameObject.Find("Worktext1");
                    GameObject cube8 = GameObject.Find("Workmode1");
                    if (i == 0)
                    {
                        if (SystemScript.japan == true)
                        {
                            cube7.GetComponent<Text>().text = "花咲くアーモンドの枝";
                            cube8.GetComponent<Text>().text = "戻る";
                        }

                        if(SystemScript.japan == false)
                        {

                        }
                    }
                    
                    count_1 = 0;
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "AR_Main2")
        {
            if (RayCastScript2.laungageon2 == true && RayCastScript2.texton2 == true && RayCastScript2.worksmode2 == true)
            {
                Flick();
                if (count == 1)
                {
                    GameObject cube7 = GameObject.Find("Worktext2");
                    GameObject cube8 = GameObject.Find("Workmode2");
                    if (SystemScript.japan == true)
                    {
                        cube7.GetComponent<Text>().text = "凱風快晴";
                        cube8.GetComponent<Text>().text = "戻る";
                    }
                    if (SystemScript.japan == false)
                    {
                        cube7.GetComponent<Text>().text = "Fine Wind, Clear Morning";
                        cube8.GetComponent<Text>().text = "back";
                    }
                    count = 0;
                }
            }
        }

        if (rightmode == true)
        {
            GameObject cube7 = GameObject.Find("Worktext2");
            GameObject cube8 = GameObject.Find("Workmode2");
            GameObject cube9 = GameObject.Find("Worktext1");
            GameObject cube10 = GameObject.Find("Workmode1");


            i++;
            if (i == 3)
            {
                i = 0;
            }
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            if (SystemScript.japan == true)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    if (i == 0)
                    {
                        cube9.GetComponent<Text>().text = "花咲くアーモンドの枝";
                    }
                    if (i == 1)
                    {
                        cube9.GetComponent<Text>().text = "アイリス";
                    }
                    if (i == 2)
                    {
                        cube9.GetComponent<Text>().text = "薔薇";
                    }
                    cube10.GetComponent<Text>().text = "戻る";
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    if (i == 0)
                    {
                        cube7.GetComponent<Text>().text = "凱風快晴";
                    }
                    if (i == 1)
                    {
                        cube7.GetComponent<Text>().text = "山下白雨";
                    }
                    if (i == 2)
                    {
                        cube7.GetComponent<Text>().text = "尾州不二見原";
                    }
                    cube8.GetComponent<Text>().text = "戻る";
                }

            }
            if (SystemScript.japan == false)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {

                    if (i == 0)
                    {
                        cube9.GetComponent<Text>().text = "Almond Blossoms";
                    }
                    if (i == 1)
                    {
                        cube9.GetComponent<Text>().text = "Iris";
                    }
                    if (i == 2)
                    {
                        cube9.GetComponent<Text>().text = "Rose";
                    }
                    cube10.GetComponent<Text>().text = "back";

                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
 

                    if (i == 0)
                    {
                        cube7.GetComponent<Text>().text = "Fine Wind, Clear Morning";
                    }
                    if (i == 1)
                    {
                        cube7.GetComponent<Text>().text = "Thunderstorm Beneath the Summit";
                    }
                    if (i == 2)
                    {
                        cube7.GetComponent<Text>().text = "Bishu Fujimigara";
                    }
                    cube8.GetComponent<Text>().text = "back";

                }

            }
            rightmode = false;



        }
        if (leftmode == true)
        {
            GameObject cube7 = GameObject.Find("Worktext2");
            GameObject cube8 = GameObject.Find("Workmode2");
            GameObject cube9 = GameObject.Find("Worktext1");
            GameObject cube10 = GameObject.Find("Workmode1");


            i--;
            if (i == -1)
            {
                i = 2;
            }
            this.GetComponent<Renderer>().sharedMaterial = _material[i];
            LogSystemScript.GimicLog++;
            if (SystemScript.japan == true)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {
                    if (i == 0)
                    {
                        cube9.GetComponent<Text>().text = "花咲くアーモンドの枝";
                    }
                    if (i == 1)
                    {
                        cube9.GetComponent<Text>().text = "アイリス";
                    }
                    if (i == 2)
                    {
                        cube9.GetComponent<Text>().text = "薔薇";
                    }
                    cube10.GetComponent<Text>().text = "戻る";
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {
                    if (i == 0)
                    {
                        cube7.GetComponent<Text>().text = "凱風快晴";
                    }
                    if (i == 1)
                    {
                        cube7.GetComponent<Text>().text = "山下白雨";
                    }
                    if (i == 2)
                    {
                        cube7.GetComponent<Text>().text = "尾州不二見原";
                    }
                    cube8.GetComponent<Text>().text = "戻る";
                }
            }
            if (SystemScript.japan == false)
            {
                if (SceneManager.GetActiveScene().name == "AR_Main")
                {

                    if (i == 0)
                    {
                        cube9.GetComponent<Text>().text = "Almond Blossoms";
                    }
                    if (i == 1)
                    {
                        cube9.GetComponent<Text>().text = "Iris";
                    }
                    if (i == 2)
                    {
                        cube9.GetComponent<Text>().text = "Rose";
                    }
                    cube10.GetComponent<Text>().text = "back";
                }
                if (SceneManager.GetActiveScene().name == "AR_Main2")
                {

                    if (i == 0)
                    {
                        cube7.GetComponent<Text>().text = "Fine Wind, Clear Morning";
                    }
                    if (i == 1)
                    {
                        cube7.GetComponent<Text>().text = "Thunderstorm Beneath the Summit";
                    }
                    if (i == 2)
                    {
                        cube7.GetComponent<Text>().text = "Bishu Fujimigara";
                    }
                    cube8.GetComponent<Text>().text = "back";
                }
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
