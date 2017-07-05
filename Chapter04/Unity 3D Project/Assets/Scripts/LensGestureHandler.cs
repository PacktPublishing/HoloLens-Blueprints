using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


/// <summary>
/// Lens Gesture Hanlder
/// </summary>
public class LensGestureHandler : MonoBehaviour, IInputClickHandler
{
    RaycastHit hit;
    bool isTapped = false;
      

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Translates the Lens Objects 
    /// </summary>
    /// <param name="y"></param>
    private void TranslateLenseObjects(float y)
    {
        var lftprojector = GameObject.FindWithTag("LeftProjector");
        var rgtprojector = GameObject.FindWithTag("RightProjector");
        var imuhlder = GameObject.FindWithTag("ImuHolder");

        lftprojector.transform.Translate(0.0f, y * Time.deltaTime, 0.0f);
        rgtprojector.transform.Translate(0.0f, y * Time.deltaTime, 0.0f);
        imuhlder.transform.Translate(0.0f, y * Time.deltaTime, 0.0f);
    }

  
    /// <summary>
    /// Handle On Click Event for Lense
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {
        hit = GazeManager.Instance.HitInfo;


        if (hit.transform.gameObject != null)
        {
            isTapped = !isTapped;

            if (isTapped)
            {
                TranslateLenseObjects(-5.0f);


                // Attach Sound Manager while  Air Tap
                var soundManager = GameObject.FindWithTag("SoundManager");
                TextToSpeechManager textToSpeech = soundManager.GetComponent<TextToSpeechManager>();
                textToSpeech.Voice = TextToSpeechVoice.Mark;
                textToSpeech.SpeakText("The HoloLens display is basically a set of transparent lenses placed just in front of the eyes.");
            }
            else
            {
                TranslateLenseObjects(5.0f);
            }
        }

    }
}
