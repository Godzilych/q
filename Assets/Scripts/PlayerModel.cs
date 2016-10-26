using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour
{
    //Base parameters
    float maxSpeed = 8;
    float maxRotSpeed;
    float physicsMass = 1;
    float accPower = 8;

    float curSpeed = 0;
    float curRotSpeed;


    float moveSpeed = 1;
    float roamSpeed = 0.15f;
    float rotationSpeed = 3;

    GameObject target;
    Vector3 direction;
    Vector3 lastPos= Vector3.zero;
    Vector3 trust;
    Vector3 drag;
    Vector3 velo;
    Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.Find("Target");
        rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        direction = (target.transform.position - transform.position).normalized;

        if (Vector3.Distance(target.transform.position, transform.position) > 0.05)
        {
            Facing(direction);
        }

        if (Vector3.Distance(transform.position, target.transform.position) > 0.05)
        {
            Move(direction);
        }
    }


    // rotate footballer to the target
    void Facing (Vector3 target)
    {
        target.y = 0;
        
        transform.rotation = Quaternion.LookRotation( Vector3.RotateTowards(transform.forward, target, rotationSpeed * (1 - curSpeed/maxSpeed) * Time.deltaTime, 0));
    }

    // move footballer in desired direction, speed depends on facing
    void Move (Vector3 direction)
    {
        curSpeed = velo.magnitude;
        float dirModifier = Mathf.Lerp(roamSpeed, moveSpeed, 1 - Vector3.Angle(transform.forward, direction) / 180);

        trust = direction * accPower / physicsMass * dirModifier * Time.deltaTime;
        drag =  velo.normalized * trust.magnitude * curSpeed / maxSpeed * -1;

        velo = velo + trust + drag;

        transform.Translate(velo * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, trust * 100, Color.red);
        Debug.DrawRay(transform.position, drag * 100, Color.green);
        Debug.DrawRay(transform.position, velo, Color.blue);
        Debug.Log("trust: " + trust.magnitude);
        Debug.Log("drag: " + drag.magnitude);
        Debug.Log("speed: " + curSpeed);
    }
}
