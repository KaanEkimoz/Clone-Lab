using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class RedButton : MonoBehaviour, IInteractable
{
    public UnityEvent OnButtonPressed;
    public UnityEvent OnButtonReleased;
    private bool isPressable = true;

    [SerializeField] private float buttonHoldTime = 3f;
    
    public void Interact()
    {
        PressButton();
    }
    private void PressButton()
    {
        Debug.Log("BUTTON PRESSED");
        OnButtonPressed?.Invoke();
        isPressable = false; 
        StartCoroutine(ButtonHold());
    }
    private void ReleaseButton()
    {
        OnButtonReleased?.Invoke();
        isPressable = true;
    }
    private IEnumerator ButtonHold()
    {
        yield return new WaitForSeconds(buttonHoldTime);
        ReleaseButton();
    }
}
