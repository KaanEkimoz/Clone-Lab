using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class BasicEnemy : MonoBehaviour
{
    [Header("Attacking")]
    [SerializeField] private GameObject target;

    [Header("Patrolling")]
    [SerializeField] private List<Transform> waypoints;
    private int _currentWaypointIndex = 0;

    [Header("Range")] 
    [SerializeField] private float sightRange = 16f;
    [SerializeField] private float attackRange = 8.1f;
    private bool _isTargetInSightRange, _isTargetInAttackRange;
    
    [Header("Layer Mask")]
    [SerializeField] private LayerMask enemySightLayerMask;
    [SerializeField] private LayerMask enemyAttackLayerMask;
    
    //Animations
    [SerializeField] private Animator _animator;
    private bool _isAttacking;
    private bool _isWalking;
    
    //Agent for pathfinding
    private NavMeshAgent _agent;
    
    private void Start()
    { 
        _agent = GetComponent<NavMeshAgent>();
        
        //if there is no target at the beginning, it finds the player and sets the target;
        if (!target)
            target = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
        //Check for sight and attack range
        _isTargetInSightRange = CheckSightRange();
        _isTargetInAttackRange = CheckAttackRange();
        
        if (_isTargetInSightRange && !_isTargetInAttackRange) ChasePlayer();
        if (_isTargetInAttackRange && _isTargetInSightRange) StartAttacking();
        if (!_isTargetInAttackRange && !_isTargetInSightRange) Patrol();
        
        UpdateAnimator();
    }
    private bool CheckSightRange()
    {
        return Physics.CheckSphere(transform.position, sightRange, enemySightLayerMask);
    }
    private bool CheckAttackRange()
    {
        return Physics.CheckSphere(transform.position, attackRange, enemyAttackLayerMask);
    }
    private void Patrol()
    {
        if(waypoints.Count == 0)
            return;
        
        if(Vector3.Distance(transform.position, waypoints[_currentWaypointIndex].position) < 0.5f)
        {
            _currentWaypointIndex++;
            if (_currentWaypointIndex == waypoints.Count)
            {
                _currentWaypointIndex = 0;
            }
        }
        _isWalking = true;
        _agent.SetDestination(waypoints[_currentWaypointIndex].position);
    }
    private void ChasePlayer()
    {
        _isWalking = true;
        _agent.SetDestination(target.transform.position);
    }
    public void StartAttacking()
    {
        _isAttacking = true;
        transform.LookAt(target.transform);
    }
    private void UpdateAnimator()
    {
        _animator.SetBool("B_IsAttacking", _isAttacking);
        _animator.SetBool("B_IsWalking", _isWalking);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
