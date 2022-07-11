using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class Predador_Agent : Agent
{
    // Start is called before the first frame update
    public float MoveSpeed = 20;
    private Vector3 orig;
    private Rigidbody rgBd;
    public  GameObject target;
    public GameObject r;

    public override void Initialize()
    {
        orig = this.transform.localPosition;
        rgBd = this.GetComponent<Rigidbody>();

    }
    public override void OnEpisodeBegin()
    {
        this.transform.localPosition = orig;
        r.GetComponent<randomChild>().RandomPOS();
    }
    public override void OnActionReceived(ActionBuffers actions)
    {
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        Vector3 force = new Vector3(moveX * MoveSpeed, 0, moveZ * MoveSpeed);
        //print("x " + moveX * MoveSpeed);
        //print("z " +moveZ * MoveSpeed);

        this.rgBd.AddForce(force);
        AddReward(((Mathf.Tan(Vector3.Distance(this.transform.position, target.transform.position)*Mathf.PI/2)*-1)+1) * 0.001f);
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition.x);
        sensor.AddObservation(target.transform.localPosition.x);
        sensor.AddObservation(transform.localPosition.y);
        sensor.AddObservation(target.transform.localPosition.y);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall"){
            AddReward(-1);
            EndEpisode();
        }
        if (collision.gameObject.tag == "Prey")
        {
            AddReward(1);
            EndEpisode();
        }
        if (collision.gameObject.tag == "Obestaculo")
        {
            AddReward(-0.05f);
            
        }
    }
}
