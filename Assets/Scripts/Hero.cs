using UnityEngine;

public class Hero : Entity
{
    RaycastHit hit = new RaycastHit();

    public Rigidbody projectile;
    public Transform startPoint;

    public float curveHeight = 3;
    private float gravity = -9.81f;

    public float fireRate = 120f;
    private float nextFire = 0f;

    private bool canShoot = false;

    void Launch(Vector3 target)
    {
        Rigidbody clone = Instantiate(projectile, startPoint.position, Quaternion.identity);
        clone.velocity = CalculateLaunchData(target).initialVelocity;
        Destroy(clone.gameObject, 10f);
    }

    LaunchData CalculateLaunchData(Vector3 target)
    {
        float displacementY = target.y - startPoint.position.y;
        Vector3 displacementXZ = new Vector3(target.x - startPoint.position.x, 0, target.z - startPoint.position.z);

        float time = Mathf.Sqrt(-2 * curveHeight / gravity) + Mathf.Sqrt(2 * (displacementY - curveHeight) / gravity);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * curveHeight);
        Vector3 velocityXZ = displacementXZ / time;

        return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);
    }

    struct LaunchData
    {
        public readonly Vector3 initialVelocity;
        public readonly float timeToTarget;

        public LaunchData(Vector3 initialVelocity, float timeToTarget)
        {
            this.initialVelocity = initialVelocity;
            this.timeToTarget = timeToTarget;
        }
    }

    protected override void Start()
    {
        base.Start();

        gravity = Physics.gravity.y;
    }

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

        if (canShoot && Input.GetMouseButton(1))
        {
            if (fireRate == 0)
            {
                Shoot();
            }
            else
            {
                if (Time.time > nextFire)
                {
                    nextFire = Time.time + 60 / fireRate;

                    Shoot();
                }
            }
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            Launch(hit.point);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canShoot = true;
    }

    private void OnTriggerExit(Collider other)
    {
        canShoot = false;
    }
}
