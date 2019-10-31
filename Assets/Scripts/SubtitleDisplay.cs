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

    public bool triggered;

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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && !triggered)
        {
            StartCoroutine(playVoiceLines());
            triggered = true;
        }
    }
}
