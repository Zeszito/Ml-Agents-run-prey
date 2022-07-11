using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class Predador_Agent : Agent
{
    // Start is called before the first frame update
    public float MoveSpeed = 20;
    private Vector3 orig;
    private Bounds bndFloor;
    private GameObject target;

    public override void Initialize()
    {
        orig = this.transform.position;
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        base.OnActionReceived(actions);
    }
}
