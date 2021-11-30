using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PhotoScript : MonoBehaviour
{
    static public bool photostart = false;

    public GameObject UI1;//スキャン画面
    public GameObject UI2;//カメラ画面
    public GameObject UI3;//デコレーション画面
    public GameObject UI5;//デコレーション決定ボタン
    public GameObject UI6;//消す決定UI
    public GameObject UI7;//色変更UI

    public GameObject GohoMenu;
    public GameObject HokusaiMenu;
    public GameObject AnotherMenu;

    static public bool Gimicmode = false;
    static public bool ObjectMovemode = false;
    static public bool EraserMode = false;

    //ゴッホのオブジェクト判定
    static public bool StarObject = false;
    static public bool CloudObject = false;
    static public bool MoonObject = false;
    static public bool TheoObject = false;
    static public bool GohoObject = false;

    //北斎のオブジェクト判定
    static public bool WaveObject_1 = false;
    static public bool WaveObject_2 = false;
    static public bool PeopleObject_1 = false;
    static public bool PeopleObject_2 = false;
    static public bool GohoHokusaiObject = false;

    //その他のオブジェクト
    static public bool IconObject = false;
    static public bool IconObject_2 = false;

    //文字オブジェクト
    static public int b = 0;
    static public bool MessageObject = false;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        //inputField = inputField.GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {

        if (FlagScript3.flag == false&&Gimicmode==false)
        {
            UI1.SetActive(false);
            UI2.SetActive(true);

        }
        if (ScreenShot.PhotoStart == true)
        {
            count = 0;
            Gimicmode =true;
            UI2.SetActive(false);
        }
        if(ScreenShot.PhotoStart == false)
        {
            if (count == 0)
            {
                Gimicmode = false;
                count++;
            }
        }

        if (FlagScript3.TextSwichOn == true)
        {
            UI3.SetActive(false);
            UI5.SetActive(true);
            UI7.SetActive(true);
            FlagScript3.TextSwichOn = false;

        }

    }

    public void BackARMain()
    {
        FlagScript3.flag = true;
        Gimicmode = false;
        SceneManager.LoadScene("AR_Main");
    }
    public void Decoration()
    {
        Gimicmode = true;
        UI3.SetActive(true);
        UI2.SetActive(false);
    }
    public void BackPhotoMode()
    {
        Gimicmode = false;
        ObjectMovemode = false;
        UI3.SetActive(false);
    }

    public void StarARMarker()
    {
        StarObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }

    public void Determine()
    {
        StarObject = false;
        CloudObject = false;
        MoonObject = false;
        TheoObject = false;
        GohoObject = false;
        WaveObject_1 = false;
        WaveObject_2 = false;
        PeopleObject_1 = false;
        PeopleObject_2 = false;
        GohoHokusaiObject = false;
        IconObject = false;
        IconObject_2 = false;
        if (MessageObject == true)
        {
            GameObject MessageText2 = GameObject.Find("MessageTextObject");
            MessageText2.name = "CompletedObject";
            UI7.SetActive(false);
            MessageObject = false;
        }

        FlagScript3.count_1 = 0;
        UI3.SetActive(true);
        UI5.SetActive(false);
    }

    public void GohoARMenu()
    {
        GohoMenu.SetActive(true);
        HokusaiMenu.SetActive(false);
        AnotherMenu.SetActive(false);
    }
    public void HokusaiARMenu()
    {
        GohoMenu.SetActive(false);
        HokusaiMenu.SetActive(true);
        AnotherMenu.SetActive(false);
    }

    public void AnotherARMenu()
    {
        GohoMenu.SetActive(false);
        HokusaiMenu.SetActive(false);
        AnotherMenu.SetActive(true);
    }

    public void CloudARMarker()
    {
        CloudObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }

    public void MoonARMarker()
    {
        MoonObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }

    public void TheoARMarker()
    {
        TheoObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void GohoARMarker()
    {
        GohoObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }

    public void Wave1ARMarker()
    {
        WaveObject_1 = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void Wave2ARMarker()
    {
        WaveObject_2 = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void People1ARMarker()
    {
        PeopleObject_1 = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void People2ARMarker()
    {
        PeopleObject_2 = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void GohoHokusaiARMarker()
    {
        GohoHokusaiObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void Icon1ARMarker()
    {
        IconObject = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }
    public void Icon2ARMarker()
    {
        IconObject_2 = true;
        UI3.SetActive(false);
        UI5.SetActive(true);
    }

    public void Eraser()
    {
        EraserMode = true;
        ObjectMovemode = false;
        UI3.SetActive(false);
        UI6.SetActive(true);
    }

    public void DetermineEraser()
    {
        EraserMode = false;
        UI3.SetActive(true);
        UI6.SetActive(false);
    }


    
    public void InputText2()
    {
        if (b == 0)
        {
            MessageObject = true;
            b++;
        }
    }

    public void WhiteColorChange()
    {
        GameObject MessageText2 = GameObject.Find("MessageTextObject");
        MessageText2.GetComponent<Text>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
    public void  BlackColorChange()
    {
        GameObject MessageText2 = GameObject.Find("MessageTextObject");
        MessageText2.GetComponent<Text>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
    }
    
}
