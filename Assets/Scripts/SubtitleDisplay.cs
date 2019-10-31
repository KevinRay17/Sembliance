using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleDisplay : MonoBehaviour
{
    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public int currentLine;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;

    public bool trigger;

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
        if (trigger)
        {
            
        }

        for (int i = 0; i < voiceOverLines.Length; i++)
        {
            if (!source.isPlaying && trigger)
            {
                source.clip = voiceOverLines[i];
                source.Play();
                i++;
            }
        }
    }

    IEnumerator playVoiceLines()
    {
        subtitles.text = subtitleTexts[currentLine];
        source.clip = voiceOverLines[currentLine];
        source.Play();
        if (currentLine < voiceOverLines.Length)
        {
            currentLine++;
            yield return new WaitForSeconds(source.clip.length);
            StartCoroutine(playVoiceLines());
        }
        else
        {
            subtitles.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "VoiceTrigger")
        {
            StartCoroutine(playVoiceLines());
        }
    }
}
