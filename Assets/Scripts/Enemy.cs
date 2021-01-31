using UnityEngine;

public class Enemy : Entity
{
    Transform[] points;
    int destination = 0;

    protected override void Start()
    {
        base.Start();

        points = GameObject.Find("WaypointsContainer").GetComponent<WaypointsContainer>().points;
    }

    protected override void Update()
    {
        base.Update();

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;

        agent.destination = points[destination].position;

        destination = (destination + 1) % points.Length;
    }
}
