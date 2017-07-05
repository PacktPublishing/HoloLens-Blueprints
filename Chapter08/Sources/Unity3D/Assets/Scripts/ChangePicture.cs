using HoloToolkit.Unity.InputModule;
using System.Collections;
using UnityEngine;

public class ChangePicture : MonoBehaviour, IInputClickHandler, IFocusable
{
    public GameObject changeImageObject;
    private Color startcolor;

    /// <summary>
    /// On Focus Enter - Gazed
    /// </summary>
    public void OnFocusEnter()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        if (r != null)
        {
            startcolor = r.material.color;
            r.material.color = Color.gray;
        }
    }

    /// <summary>
    /// On Focus Exit - Gaze Exit
    /// </summary>
    public void OnFocusExit()
    {
        Renderer r = this.gameObject.GetComponent<Renderer>();
        if (r != null)
        {
            r.material.color = startcolor;
        }
    }

    /// <summary>
    /// Handle the Tap Event for Refresh Click
    /// </summary>
    public void OnInputClicked(InputEventData eventData)
    {
        WWW www = new WWW("https://ch8assets.blob.core.windows.net/3dassets/painting_a.png");
        StartCoroutine(DownloadAssets(www));
    }

    /// <summary>
    /// Download the Texture
    /// </summary>
    /// <param name="www"></param>
    /// <returns></returns>
    private IEnumerator DownloadAssets(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            Destroy(changeImageObject.GetComponent<Renderer>().material.mainTexture);
            changeImageObject.GetComponent<Renderer>().material.mainTexture = www.texture;

        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
