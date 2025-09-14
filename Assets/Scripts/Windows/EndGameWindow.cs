using UnityEngine.Events;

public class EndGameWindow : Window
{
    public event UnityAction RestartButtonClicked;

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        WindowGroup.blocksRaycasts = false;
        WindowGroup.interactable = false;
    }

    public override void OnButtonClick()
    {
        RestartButtonClicked?.Invoke();
    }

    public override void Open()
    {
        WindowGroup.alpha = 1.0f;
        WindowGroup.blocksRaycasts = true;
        WindowGroup.interactable = true;
    }
}
