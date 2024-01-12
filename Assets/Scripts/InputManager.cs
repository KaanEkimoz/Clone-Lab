using UnityEngine;
public class InputManager : MonoBehaviour
{
    public static GameInputActions GameInputAction { get; private set; }
    private void Awake()
    {
        GameInputAction = new GameInputActions();
        GameInputAction.Enable();
    }
}
