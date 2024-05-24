using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DucksPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private int currentPoint = 0;
    private NavMeshAgent agent;


    public float minPauseDuration = 1f;
    public float maxPauseDuration = 3f;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextPoint();
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(PauseBeforeNextMove(Random.Range(minPauseDuration, maxPauseDuration)));
        }
    }
    IEnumerator PauseBeforeNextMove(float duration)
    {
        agent.isStopped = true;
        yield return new WaitForSeconds(duration);
        agent.isStopped = false;
        MoveToNextPoint();
    }
    void MoveToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        Vector3 randomPoint = patrolPoints[Random.Range(0, patrolPoints.Length)].position;

        agent.SetDestination(randomPoint);
    }
}