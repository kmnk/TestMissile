using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    [SerializeField]
    GameObject target;

    float ratio = 3000f;

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
        var acceleration = transform.up * 200f;

        // velocity の最大値を決めておかないとだんだん振幅が大きくなってしまう？
        _velocity += acceleration * Time.deltaTime;
        _position += _velocity * Time.deltaTime;
        transform.position = _position;
    }

    void FixedUpdate()
    {
        var diff = target.transform.position - transform.position;

        var targetRot = Quaternion.LookRotation(diff) * rotOffset;

        var q = targetRot * Quaternion.Inverse(transform.rotation);

        var torque = new Vector3(q.x, q.y, q.z) * ratio;

        GetComponent<Rigidbody>().AddTorque(torque);
    }

}
