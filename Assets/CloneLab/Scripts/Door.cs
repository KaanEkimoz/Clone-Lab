using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private float doorFreezeTime = 2.0f;
    private Animator _doorAnim;
    private static readonly int DoorOpen = Animator.StringToHash("T_DoorOpen");
    private static readonly int DoorClosed = Animator.StringToHash("T_DoorClosed");
    
    public UnityEvent OnDoorOpened;
    public UnityEvent OnDoorClosed;

    private void Start()
    {
        if (!_doorAnim)
            _doorAnim = GetComponent<Animator>();
    }

    public void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        _doorAnim.SetTrigger(DoorOpen);
        StartCoroutine(DoorFreeze());
        OnDoorOpened.Invoke();
    }
    private IEnumerator DoorFreeze()
    {
        yield return new WaitForSeconds(doorFreezeTime);
        CloseDoor();
    }

    private void CloseDoor()
    {
        _doorAnim.SetTrigger(DoorClosed);
        OnDoorClosed.Invoke();
    }

}
