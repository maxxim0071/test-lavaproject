using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator), typeof(NavMeshAgent))]
public class Entity : MonoBehaviour
{
    protected Animator animator;
    protected NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    protected virtual void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
