using UnityEngine;

public class Missile : MonoBehaviour
{

    public GameObject Target;

    float torqueRatio = 10000f;
    float accelerationRatio = 200f;

    // カプセルの向きを補正
    Quaternion rotOffset = Quaternion.AngleAxis(90.0f, Vector3.right);

    Vector3 _velocity;
    Vector3 _position;

    void Start()
    {
        _position = transform.position;
    }

    void Update()
    {
        var acceleration = transform.up * accelerationRatio;

        _velocity += acceleration * Time.deltaTime;
        _position += _velocity * Time.deltaTime;
        transform.position = _position;
    }

    void FixedUpdate()
    {
        var diff = Target.transform.position - transform.position;

        var targetRot = Quaternion.LookRotation(diff) * rotOffset;

        var q = targetRot * Quaternion.Inverse(transform.rotation);

        var torque = new Vector3(q.x, q.y, q.z) * torqueRatio;

        GetComponent<Rigidbody>().AddTorque(torque);
    }

}
