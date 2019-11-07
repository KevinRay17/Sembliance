using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitleDisplay : MonoBehaviour
{
    public DialogueManager manager;

    public string[] subtitleTexts;
    public AudioClip[] voiceOverLines;

    public bool triggered;
    public GameObject glitch;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            manager.PlayVoice();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //also, only call if the boolean corresponsing to this trigger in the static boolean array is false
        if (other.gameObject.name == "Player" && !triggered)
        {
            triggered = true; // Ensures this trigger won't start again
            manager.source.Stop(); // Stops current audio
            manager.currentLine = 0; // Resets current line
            manager.subtitleTexts.Clear(); // Clears current set of subtitles
            manager.voiceOverLines.Clear(); // Clears current set of lines
            manager.subtitleTexts.AddRange(subtitleTexts); // Adds new subtitles
            manager.voiceOverLines.AddRange(voiceOverLines); // Adds new lines

            if (manager.currentTrigger != null)
            {
                Destroy(manager.currentTrigger); // Destroys the old trigger
            }
            manager.currentTrigger = this.gameObject; // Adds the new trigger


            //find index of this trigger in manager.voice triggers
            //set the boolean at that same index in the isVoiceTriggered array to true




        //GLitch
        if (gameObject.CompareTag("GlitchTrigger"))
            {
                glitch.SetActive(true);
            }



        }
    }
}
