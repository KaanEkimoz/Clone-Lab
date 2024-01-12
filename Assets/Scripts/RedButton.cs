using UnityEngine;
using UnityEngine.Events;
public class RedButton : MonoBehaviour, IInteractable
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;

    [SerializeField] private float buttonHoldTime;
    
    public void Interact()
    {
        PressButton();
    }
    private void PressButton()
    {
        OnButtonPressed?.Invoke();
    }
    private void ReleaseButton()
    {
        OnButtonReleased?.Invoke();
    }
}
