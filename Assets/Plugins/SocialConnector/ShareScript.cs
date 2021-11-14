using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShareScript : MonoBehaviour
{
    public Text Comment;

    public void TweetButton()
    {
        Comment = Comment.GetComponent<Text>();
        string TwitterLog = Comment.text.ToString();
        string text = "ARガイドでゴッホの絵画を見てきたよ！感想は「" + TwitterLog + "」\nVRのガイドも体験してみよう！ \n#XRGUIDEMUSEUM";
        string url = "https://cluster.mu/w/f1e2a624-6d3c-48a8-b591-6d59a32475d9";
        string image = null;
        SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, text, url, image);
    
    }
    public void TweetButton2()
    {
        Comment = Comment.GetComponent<Text>();
        string TwitterLog = Comment.text.ToString();
        string text = "ARガイドで北斎の絵画を見てきたよ！感想は「" + TwitterLog + "」\nVRのガイドも体験してみよう！\n #XRGUIDEMUSEUM";
        string url = "https://cluster.mu/w/f1e2a624-6d3c-48a8-b591-6d59a32475d9";
        string image = null;
        SocialConnector.PostMessage(SocialConnector.ServiceType.Twitter, text, url, image);

    }


}
