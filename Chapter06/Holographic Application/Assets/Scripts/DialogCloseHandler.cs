using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class DialogCloseHandler : MonoBehaviour, IInputClickHandler
{
    /// <summary>
    /// Handle the Click Event
    /// </summary>
    /// <param name="eventData"></param>
    public void OnInputClicked(InputEventData eventData)
    {
        GameObject detailsPanel = GameObject.FindWithTag("DetailsPanel");
        if (detailsPanel != null)
        {
            CanvasGroup detailsPanelRenderer = detailsPanel.GetComponentInChildren<CanvasGroup>();
            detailsPanelRenderer.alpha = 0;
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
