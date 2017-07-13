using UnityEngine;

/// <summary>
/// Voice Command Handler
/// </summary>
public class VoiceCommandHandler : MonoBehaviour
{
    private bool isShowing = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowSpeaker()
    {
        if (!isShowing)
        {
            var lftSpeakerDetails = GameObject.FindWithTag("speakerDetails");
            MeshRenderer render = lftSpeakerDetails.GetComponentInChildren<MeshRenderer>();
            gameObject.transform.Translate(0.0f, -1.0f * Time.deltaTime,

            0.0f);

            render.enabled = true;
            isShowing = true;
        }
    }


    public void HideSpeaker()
    {
        if (isShowing)
        {
            gameObject.transform.Translate(0.0f, 1.0f * Time.deltaTime,


            0.0f);
            var lftSpeakerDetails = GameObject.FindWithTag("speakerDetails");
            MeshRenderer render = lftSpeakerDetails.GetComponentInChildren<MeshRenderer>();
            render.enabled = false;
            isShowing = false;
        }
    }
}

