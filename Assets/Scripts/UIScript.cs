using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    static public bool VoiceOn = true;
    static public bool TextOn = true;
    static public bool LaungageOn = true;
    static public bool AROn = true;

    public Text Voice;
    public Text Text;
    public Text Laungage;
    public Text AR;

    AudioSource audioSource;
    public AudioClip sound1;

    public Text Voicetext;
    public Text Texttext;
    public Text Laungagetext;
    public Text UImenu;
    public Text determine;
    public Text ARtext;

   

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (VoiceOn == true)
        {
           Voice.text = "ON";
        }
        if(VoiceOn == false)
        {
           Voice.text = "OFF";
        }

        if (TextOn == true)
        {
            Text.text = "ON";
        }
        if (TextOn == false)
        {
            Text.text = "OFF";
        }
        if (LaungageOn == true)
        {
            Laungage.text = "ON";
        }
        if (LaungageOn == false)
        {
            Laungage.text = "OFF";
        }
        if(AROn == true)
        {
            AR.text = "ON";
        }
        if(AROn == false)
        {
            AR.text = "OFF";
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SystemScript.japan == true)
        {
            Voicetext.text = "音声ガイド";
            Texttext.text = "テキストガイド";
            Laungagetext.text = "言語切り替えボタン";
            UImenu.text = "UI表示設定";
            determine.text = "決定";
            ARtext.text = "ARモード";
        }
        if (SystemScript.japan == false)
        {
            Voicetext.text = "Voice Guide";
            Texttext.text = "Text Guide";
            Laungagetext.text = "Choose Laungage Button";
            UImenu.text = "UI Display Setting";
            determine.text = "determine";
            ARtext.text = "AR MODE";
        }
    }

    public void voiceGuideOn()
    {
        audioSource.PlayOneShot(sound1);
        if (VoiceOn == true)
        {
            VoiceOn = false;
            Voice.text = "OFF";
            return;
        }
        if (VoiceOn == false)
        {
            VoiceOn = true;
            Voice.text = "ON";
            return;
        }
    }

    public void textGuideOn()
    {
        audioSource.PlayOneShot(sound1);
        if (TextOn == true)
        {
            TextOn = false;
            Text.text = "OFF";
            return;
        }
        if (TextOn == false)
        {
            TextOn = true;
            Text.text = "ON";
            return;
        }
    }
    public void LaungageGuideOn()
    {
        audioSource.PlayOneShot(sound1);
        if (LaungageOn == true)
        {
            LaungageOn = false;
            Laungage.text = "OFF";
            return;
        }
        if (LaungageOn == false)
        {
            LaungageOn = true;
            Laungage.text = "ON";
            return;
        }
    }
    public void ARGUideOn()
    {
        audioSource.PlayOneShot(sound1);
        if (AROn == true)
        {
            AROn = false;
            AR.text = "OFF";
            return;
        }
        if (AROn == false)
        {
            AROn = true;
            AR.text = "ON";
            return;
        }
    }

}
