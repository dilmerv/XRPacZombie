﻿using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PatrolAgentProcedural : MonoBehaviour
{
    [SerializeField]
    private List<Transform> points = new List<Transform>();

    [SerializeField]
    private Transform playerDestination;

    [SerializeField]
    private float minRemainingDistance = 0.5f;

    private int destinationPoint = 0;

    private NavMeshAgent agent;

    public int PointCount => points.Count;

    public void AddPoint(Transform point)
    {
        points.Add(point);
    }

    public void AddPoints(Transform[] points)
    {
        this.points.AddRange(points);
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (points.Count == 0)
        {
            return;
        }

        agent.destination = points[destinationPoint].position;
        destinationPoint = (destinationPoint + 1) % points.Count;
    }

    void GoToPlayer()
    {
        if (playerDestination == null)
        {
            return;
        }

        agent.destination = playerDestination.position;
    }

    private void Update()
    {
        if (!agent.enabled)
        {
            return;
        }

        if (GameManager.Instance.gameMode == GameManager.GameMode.Zombie)
        {
            GoToPlayer();
            return;
        }

        if (!agent.pathPending && agent.remainingDistance < minRemainingDistance)
        {
            if (GameManager.Instance.gameMode == GameManager.GameMode.Normal)
            {
                GoToNextPoint();
            }
        }
    }
}