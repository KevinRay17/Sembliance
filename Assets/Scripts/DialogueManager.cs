using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public Image panelShort;
    public Image panelTall;

    public GameObject currentTrigger;
    public int currentLine;

    public List<string> subtitleTexts;
    public List<AudioClip> voiceOverLines;

    //in inspector, drag all voice trigger objects into this array
    //public SubtitleDisplay[] voiceTriggers;

    //public static bool[] isVoiceTriggered;
    //public static bool triggersSetUp;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //if (!triggersSetUp)
        //{
        //    triggersSetUp = true;
        //    //here i want to fill my boolean array with all false. it should be the 
        //    //length of the SubtitleDisplay array
        //}
        subtitles = GameObject.Find("Subtitles").GetComponent<TextMeshProUGUI>();
        source = GameObject.Find("Subtitles").GetComponent<AudioSource>();

        panelShort = GameObject.Find("PanelShort").GetComponent<Image>();
        panelTall = GameObject.Find("PanelTall").GetComponent<Image>();

        subtitles.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            subtitles.text = "";
            panelShort.enabled = false;
            panelTall.enabled = false;
        }

        PlayVoice();
    }

    public void PlayVoice()
    {
        if (currentLine < voiceOverLines.Count && !source.isPlaying)
        {
            subtitles.text = subtitleTexts[currentLine];
            source.clip = voiceOverLines[currentLine];
            source.Play();
            
            //Debug.Log("Is the text overflowing? " + subtitles.isTextOverflowing);
            //char[] characters = subtitleTexts[currentLine].ToCharArray();
            //print(characters.Length);

            if (subtitles.isTextOverflowing)
            {
                panelTall.enabled = false;
                panelShort.enabled = true;
            }
            else
            {
                panelTall.enabled = true;
                panelShort.enabled = false;
            }
            currentLine++;
        }
    }
}
