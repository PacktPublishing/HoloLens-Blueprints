using HoloToolkit.Unity.InputModule;
using System;
using UnityEngine;

public class ProductRemover : MonoBehaviour, IInputClickHandler, IFocusable
{

    public GameObject toberemovedObject;
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
    /// Handle the Tap Event on Remove Button
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {

        try
        {
            Destroy(toberemovedObject);
            Transform gg = transform.parent.gameObject.transform.parent;
            Destroy(transform.parent.gameObject);
        }
        catch (Exception ex)
        {
            Debug.Log(ex.Message);
        }

    }
}
