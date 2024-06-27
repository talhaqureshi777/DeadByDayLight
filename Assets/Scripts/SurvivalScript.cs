using UnityEngine;
using UnityEngine.AI;

public class SurvivalScript : MonoBehaviour
{
    public float wanderRadius = 10f;
    public float minDistanceToDestination = 1f; // Minimum distance to consider the destination reached

    private NavMeshAgent agent;
    private Vector3 targetPosition;
    private bool isStopped = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetNewRandomDestination();
    }

    void Update()
    {
        if (isStopped) return;

        // Check if the enemy has reached its destination
        if (!agent.pathPending && agent.remainingDistance <= minDistanceToDestination)
        {
            SetNewRandomDestination();
        }
    }

    void SetNewRandomDestination()
    {
        // Get a new random position within the wander radius
        targetPosition = RandomNavSphere(transform.position, wanderRadius, -1);
        agent.SetDestination(targetPosition);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randomDirection = Random.insideUnitSphere * dist;
        randomDirection += origin;

        NavMeshHit navHit;
        NavMesh.SamplePosition(randomDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    public void StopMovement()
    {
        isStopped = true;
        agent.isStopped = true;
    }

    public void ResumeMovement()
    {
        isStopped = false;
        agent.isStopped = false;
        SetNewRandomDestination();
    }
}
