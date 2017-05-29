using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehavious
{
    public Transform target;
    public float stoppingDistance = 1f;
    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;
        if(target == null)
        {
            return force;
        }
        Vector3 desForce = target.position - owner.transform.position;
        desForce.y = 0;
        if(desForce.magnitude > stoppingDistance)
        {
            desForce = desForce.normalized * waighting;
            force = desForce - owner.velocity;
        }
        return force;
    }

}
