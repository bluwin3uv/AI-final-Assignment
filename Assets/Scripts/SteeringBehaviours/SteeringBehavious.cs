using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIAgent))]
public class SteeringBehavious : MonoBehaviour
{
    public float waighting = 7.5f;
    [HideInInspector] public AIAgent owner;
	void Awake ()
    {
        owner = GetComponent<AIAgent>();
	}
	public virtual Vector3 GetForce()
    {
        return Vector3.zero;
    }
}
