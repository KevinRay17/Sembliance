using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public GameObject currentTrigger;
    public int currentLine;

    public List<string> subtitleTexts;
    public List<AudioClip> voiceOverLines;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        subtitles = GameObject.Find("Subtitles").GetComponent<TextMeshProUGUI>();
        source = GameObject.Find("Subtitles").GetComponent<AudioSource>();

        subtitles.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            subtitles.text = "";
        }

        PlayVoice();
    }

    public IEnumerator playVoiceLines()
    {
        subtitles.text = subtitleTexts[currentLine];
        source.clip = voiceOverLines[currentLine];
        source.Play();
        if (currentLine < voiceOverLines.Count)
        {
            currentLine++;
            yield return new WaitForSeconds(source.clip.length);
            StartCoroutine(playVoiceLines());
        }
        //subtitleTexts.Clear();
        //voiceOverLines.Clear();
    }

    public void PlayVoice()
    {
        if (currentLine < voiceOverLines.Count)
        {
            if (!source.isPlaying)
            {
                subtitles.text = subtitleTexts[currentLine];
                source.clip = voiceOverLines[currentLine];
                source.Play();

                currentLine++;
            }
            else
            {
                
            }
        }
    }
}
