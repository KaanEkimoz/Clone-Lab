using UnityEngine;
using StarterAssets;

public class PlayerClone : MonoBehaviour
{
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private TrailRenderer cloneTrail;
    private Animator _animator;
    private StarterAssetsInputs _input;
    private GameObject clone;
    private Transform cloneTransform => clone.transform;
    private Transform playerTransform => transform;

    private int _animIDRage;
    private void Start()
    {
        _input = GetComponent<StarterAssetsInputs>();
        _animator = GetComponent<Animator>();
        AssignAnimationIDs();
        if (!clone)
        {
            clone = Instantiate(clonePrefab);
            clone.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        CloneToggle();
    }
    private void CloneToggle()
    {
        if (_input.clone)
        {
            if(clone.gameObject.activeSelf)
                CallBackToClonePosition();
            else
                CreateClone();

            _input.clone = false;
        }
    }
    private void CreateClone()
    {
        clone.SetActive(true);
        cloneTrail.time = 5;
        cloneTransform.position = playerTransform.position;
        cloneTransform.eulerAngles = playerTransform.eulerAngles;
        _animator.SetTrigger(_animIDRage);
    }
    private void CallBackToClonePosition()
    {
        cloneTrail.time = 0;
        playerTransform.position = cloneTransform.position;
        playerTransform.eulerAngles = cloneTransform.eulerAngles;
        clone.SetActive(false);
    }
    private void AssignAnimationIDs()
    {
        _animIDRage = Animator.StringToHash("Rage");
    }
}
