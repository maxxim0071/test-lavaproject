using UnityEngine;

public class Hero : Entity
{
    RaycastHit hit = new RaycastHit();

    protected override void Update()
    {
        base.Update();

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                agent.destination = hit.point;
            }
        }
    }
}
