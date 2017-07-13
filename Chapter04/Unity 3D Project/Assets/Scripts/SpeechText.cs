using HoloToolkit.Unity;
using UnityEngine;

/// <summary>
/// Speech Tech
/// </summary>
public class SpeechText : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        TextToSpeechManager textToSpeechManager = this.GetComponent<TextToSpeechManager>();
        textToSpeechManager.Voice = TextToSpeechVoice.Mark;
        textToSpeechManager.SpeakText("Welcome To Explore HoloLens. A Holographic View of a HoloLens device. You can use Gaze, Gesture and Voice Command to explore different components. Walk around and start exploring !");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
