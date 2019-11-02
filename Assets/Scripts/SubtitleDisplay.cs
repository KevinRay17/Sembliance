using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SubtitleDisplay : MonoBehaviour
{
    public DialogueManager manager;

    public TextMeshProUGUI subtitles;
    public AudioSource source;

    public int currentLine;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;

    public bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();

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
        if (triggered)
        {
            manager.PlayVoice();
        }
    }

    //IEnumerator playVoiceLines()
    //{
    //    subtitles.text = subtitleTexts[currentLine];
    //    source.clip = voiceOverLines[currentLine];
    //    source.Play();
    //    if (currentLine < voiceOverLines.Length)
    //    {
    //        currentLine++;
    //        yield return new WaitForSeconds(source.clip.length);
    //        StartCoroutine(playVoiceLines());
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !triggered)
        {
            manager.source.Stop();
            manager.currentLine = 0;
            triggered = true;
            manager.subtitleTexts.Clear();
            manager.voiceOverLines.Clear();
            manager.subtitleTexts.AddRange(subtitleTexts);
            manager.voiceOverLines.AddRange(voiceOverLines);

            if (manager.currentTrigger != null)
            {
                Destroy(manager.currentTrigger);
            }
            manager.currentTrigger = this.gameObject;

            //StopCoroutine(manager.playVoiceLines());
            //StartCoroutine(manager.playVoiceLines());
        }
    }
}
