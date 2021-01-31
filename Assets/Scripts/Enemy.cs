using UnityEngine;

public class Enemy : Entity
{
    Transform[] points = new Transform[0];
    int destination = 0;

    protected override void Start()
    {
        base.Start();

        GameObject waypointsContainer;

        if (waypointsContainer = GameObject.Find("WaypointsContainer"))
        {
            points = waypointsContainer.GetComponent<WaypointsContainer>().points;
        }
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

    public void GotHit()
    {
        agent.enabled = false;
        animator.enabled = false;
        enabled = false;

        Destroy(gameObject, 10f);
    }
}
