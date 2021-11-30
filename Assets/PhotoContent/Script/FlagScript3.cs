using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlagScript3 : MonoBehaviour
{
    [Header("ARモードで使う生成オブジェクト")]
    public GameObject AR_Star;
    public GameObject AR_Cloud;
    public GameObject AR_Moon;
    public GameObject AR_Theo;
    public GameObject AR_Goho;
    //Hokusai
    public GameObject AR_Wave1;
    public GameObject AR_Wave2;
    public GameObject AR_People1;
    public GameObject AR_People2;
    public GameObject AR_GohoHokusai;
    //Another
    public GameObject AR_Icon1;
    public GameObject AR_Icon2;
    static public int count_1 = 0;
    GameObject AR_GameObject3;

    //position
    float instantiatex = 0.0399542f;
    float instantiatey = 0.05107207f;
    float instantiatez = 0.55f;

    //TextMessage
    public GameObject MessageMain;
    static public bool TextSwichOn = false;

    static public bool flag = true;//このオブジェクトがオンになったかどうか
    // Start is called before the first frame update
    void Start()
    {
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PhotoScript.StarObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Star, new Vector3(-0.03737254f, 0.02917927f, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.CloudObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Cloud, new Vector3(0.05493844f, 0.06319314f, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.MoonObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Moon, new Vector3(0.181145f, 0.1172716f, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.TheoObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Theo, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.GohoObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Goho, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }

        if (PhotoScript.WaveObject_1 == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Wave1, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.WaveObject_2 == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Wave2, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.PeopleObject_1 == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_People1, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.PeopleObject_2 == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_People2, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.GohoHokusaiObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_GohoHokusai, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.IconObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Icon1, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.IconObject_2 == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(AR_Icon2, new Vector3(instantiatex, instantiatey, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                PhotoScript.ObjectMovemode = true;
                count_1++;
            }
        }
        if (PhotoScript.MessageObject == true)
        {
            if (count_1 == 0)
            {
                AR_GameObject3 = Instantiate(MessageMain, new Vector3(instantiatex, 0.15107207f, instantiatez), Quaternion.identity);
                AR_GameObject3.transform.parent = this.gameObject.transform;
                GameObject MessageText = GameObject.Find("MainText");//登録用
                GameObject MessageText2 = GameObject.Find("MessageTextObject");//出力用
                MessageText2.GetComponent<Text>().text = MessageText.GetComponent<Text>().text;
                //MessageText2.name = "CompletedObject";
                TextSwichOn = true;
                PhotoScript.ObjectMovemode = true;
                PhotoScript.b = 0;
                count_1++;
            }
        }

    }
}
