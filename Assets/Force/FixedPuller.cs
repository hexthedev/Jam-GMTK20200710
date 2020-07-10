using UnityEngine;

public class FixedPuller : AForceProvider
{
    public float forceFac = 1;
    public float distanceFac = 1;   

    public Vector2 pull;
    public float pull_mag;
    public Vector2 direction;

    public void Awake()
    {
        ForceManager.Providers.Add(this);
    }

    public override void ApplyFrameForce(Rigidbody2D mb)
    {
        pull = transform.position - mb.transform.position;
        pull_mag =  1 * distanceFac / pull.magnitude;
        direction = pull.normalized;

        mb.AddForce(direction * Time.fixedDeltaTime * forceFac * pull_mag);
    }
}