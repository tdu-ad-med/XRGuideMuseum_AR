using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputTextScript : MonoBehaviour
{

    public InputField inputField;
    //public Text Comment;
    static public string CommentSave;
    static public string CommentSave2;
    static public bool CommentStart = false;
    public GameObject FinishComment;
    static public bool GohoMode = true;

    public GameObject LeftMark;
    public GameObject RightMark;

    public GameObject work_paiting;
    public Image works;
    private Sprite sprite;
    private Sprite sprite2;

    public GameObject GohoButton;
    public GameObject HokusaiButton;

 

    // Start is called before the first frame update
    void Start()
    {
        inputField = inputField.GetComponent<InputField>();
        //Comment = Comment.GetComponent<Text>();
        sprite = Resources.Load<Sprite>("Hokusai");
        works = work_paiting.GetComponent<Image>();
        sprite2 = Resources.Load<Sprite>("gohho2");
        GohoMode = true;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void InputLogger()
    {
        
        string inputValue = inputField.text;
        if (GohoMode == true)
        {
            CommentSave = inputValue;
        }
        if (GohoMode == false)
        {
            CommentSave2 = inputValue;
        }

    }

    public void ConnectionText()
    {
        
        FinishComment.SetActive(true);
        if (GohoMode == true)
        {
            GohoButton.SetActive(true);
            HokusaiButton.SetActive(false);
        }
        if(GohoMode == false)
        {
            GohoButton.SetActive(false);
            HokusaiButton.SetActive(true);
        }

        CommentStart = true;
           
    }
    public void ConnectionReturn()
    {
        if (GohoMode == true)
        {
            SceneManager.LoadScene("AR_Main");
        }
        if (GohoMode == false)
        {
            SceneManager.LoadScene("AR_Main2");
        }

    }
    public void Right()
    {
        GohoMode = false;
        works.sprite = sprite;
        LeftMark.SetActive(true);
        RightMark.SetActive(false);
    }
    public void Left()
    {
        GohoMode = true;
        works.sprite = sprite2;
        LeftMark.SetActive(false);
        RightMark.SetActive(true);
    }
}
