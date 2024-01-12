using System.Collections;
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
        StartCoroutine(ButtonHold());
    }
    private void ReleaseButton()
    {
        OnButtonReleased?.Invoke();
    }
    private IEnumerator ButtonHold()
    {
        yield return new WaitForSeconds(buttonHoldTime);
        ReleaseButton();
    }
}
