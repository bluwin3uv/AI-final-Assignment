using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

public class Wander : SteeringBehavious
{
    public float offset = 1;
    public float radius = 1;
    public float jitter = 0.2f;
    private Vector3 targetDirection;
    private Vector3 randomDirection;
    private Vector3 circlePosition;
    private Vector3 desForce;

    public override Vector3 GetForce()
    {
        Vector3 force = Vector3.zero;
        float randX = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);
        float randZ = Random.Range(0, 0x7fff) - (0x7fff * 0.5f);

        #region calculate Random Direction
        randomDirection = new Vector3(randX, 0, randZ);
        randomDirection = randomDirection.normalized;
        randomDirection = randomDirection * jitter;
        #endregion

        #region Calculate target Direction
        targetDirection += randomDirection;
        targetDirection = targetDirection.normalized;
        targetDirection = targetDirection * radius;
        #endregion

        #region Calculate force
        Vector3 SeekPosition = owner.transform.position + targetDirection;
        SeekPosition += owner.transform.forward * offset;
        #region GIZMO
        Vector3 offsetPosition = transform.position + transform.forward.normalized * offset;
        GizmosGL.AddCircle(offsetPosition + Vector3.up * 0.02f, radius, Quaternion.LookRotation(Vector3.down), 16, Color.red);
        GizmosGL.AddCircle(SeekPosition + Vector3.up * 0.03f, radius * 0.6f, Quaternion.LookRotation(Vector3.down), 16, Color.blue);
        #endregion
        desForce = SeekPosition - transform.position;
        if(desForce != Vector3.zero)
        {
            desForce = desForce.normalized * waighting;
            force = desForce - owner.velocity;
        }
        #endregion
        return force;
    }
}
