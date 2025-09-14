using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartWindow : Window
{
    public event UnityAction PlayButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.interactable = false;
        WindowGroup.blocksRaycasts = false;
    }

    public override void OnButtonClick()
    {
        PlayButtonClicked?.Invoke();
    }

    public override void Open()
    {
        WindowGroup.alpha = 1.0f;
        WindowGroup.interactable = true;
        WindowGroup.blocksRaycasts = true;
    }
}
