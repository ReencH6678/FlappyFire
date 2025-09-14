using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int _leftMouseButtonIndex = 0;
    private const int _rightMouseButtonIndex = 1;

    public bool IsLeftMouseButtonPressed {  get; private set; }
    public bool IsRightMouseButtonPressed {  get; private set; }

    private void Update()
    {
        IsLeftMouseButtonPressed = Input.GetMouseButtonDown(_leftMouseButtonIndex);
        IsRightMouseButtonPressed = Input.GetMouseButtonUp(_rightMouseButtonIndex);
    }
}
