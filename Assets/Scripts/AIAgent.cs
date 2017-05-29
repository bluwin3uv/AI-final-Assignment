using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAgent : MonoBehaviour
{
    public Vector3 force;
    private float moveSpeed;
    public Vector3 velocity;
    public float maxVelo;
    private SteeringBehavious[] behaviours;
    private Animator anim;
	void Start ()
    {
        anim = GetComponent<Animator>();
        behaviours = GetComponents<SteeringBehavious>();
	}
	
	void Update ()
    {
        ComputeForces();
        AppyVelocity();
        moveSpeed = velocity.magnitude;
        anim.SetFloat("MoveSpeed", moveSpeed);

	}

    void ComputeForces()
    {
        force = Vector3.zero;
        for(int i =0; i < behaviours.Length;i++)
        {
            if(behaviours[i].enabled == false)
            {
                continue;
            }
            force += behaviours[i].GetForce();
            if(force.magnitude > maxVelo)
            {
                force = force.normalized * maxVelo;
                break;
            }
        }
    }
    void AppyVelocity()
    {
        velocity += force * Time.deltaTime;
        if(velocity.magnitude > maxVelo)
        {
            velocity = velocity.normalized * maxVelo;
        }
        if(velocity.magnitude > 0)
        {
            transform.position += velocity * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(velocity);
        }
    }
}
