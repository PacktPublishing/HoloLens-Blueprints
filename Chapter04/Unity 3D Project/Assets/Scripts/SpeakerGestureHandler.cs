using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using UnityEngine;


/// <summary>
/// Speaker Gesture Handler
/// </summary>
public class SpeakerGestureHandler : MonoBehaviour, IInputClickHandler
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
    /// Handle Air Tap for Speaker
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {
        hit = GazeManager.Instance.HitInfo; if (hit.transform.gameObject != null)
        {
            isTapped = !isTapped;
            var lftSpeaker = GameObject.FindWithTag("LeftSpeaker"); var lftSpeakerDetails =
            GameObject.FindWithTag("speakerDetails"); MeshRenderer render =
            lftSpeakerDetails.GetComponentInChildren<MeshRenderer>();


            if (isTapped)
            {
                lftSpeaker.transform.Translate(0.0f, -1.0f * Time.deltaTime, 0.0f);
                render.enabled = true;

            }
            else
            {
                lftSpeaker.transform.Translate(0.0f, 1.0f * Time.deltaTime, 0.0f);
                render.enabled = false;
            }


        }
    }


}



