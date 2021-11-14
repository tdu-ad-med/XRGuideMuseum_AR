using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    [Header("設定画面の言語変換用テキスト")]
    public Text Voicetext;
    public Text Texttext;
    public Text Laungagetext;
    public Text UImenu;
    public Text determine;

   

    // Start is called before the first frame update
    void Start()
    {
    


    }

    // Update is called once per frame
    void Update()
    {
        if (SystemScript.japan == true)
        {
            Voicetext.text = "クイズコンテンツ";
            Texttext.text = "写真コンテンツ";
            Laungagetext.text = "コミュニケーション";
            UImenu.text = "コンテンツメニュー";
            determine.text = "決定";

        }
        if (SystemScript.japan == false)
        {
            Voicetext.text = "Quiz Content";
            Texttext.text = "Picture Content";
            Laungagetext.text = "Communication";
            UImenu.text = "Content Menu";
            determine.text = "determine";

        }
    }

    public void voiceGuideOn()
    {
        


    }

    public void textGuideOn()
    {
        
        
    }
    public void LaungageGuideOn()
    {
        SceneManager.LoadScene("Communication");
    }


}
