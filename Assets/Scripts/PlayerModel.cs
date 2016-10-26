using UnityEngine;
using System.Collections;

public class PlayerModel : MonoBehaviour
{
    //Base parameters
    float maxSpeed = 8;
    float maxRotSpeed;
    float physicsMass = 1;
    float accPower = 8;
    float dragBase = 2f;

    float curSpeed = 0;
    float curRotSpeed;


    float moveSpeed = 1;
    float roamSpeed = 0.15f;
    float rotationSpeed = 2;

    public GameObject targetObj;
    Vector3 direction;
    Vector3 directionTrue;
    Vector3 lastPos= Vector3.zero;
    Vector3 trust;
    Vector3 drag;
    Vector3 velo;

    // Use this for initialization
    void Start ()
    {
        targetObj = GameObject.Find("Target");
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (targetObj.activeInHierarchy==true)
        {
            directionTrue = (targetObj.transform.position - transform.position).normalized;
            direction = (targetObj.transform.position - transform.position - velo).normalized;
        }

        if (Vector3.Distance(targetObj.transform.position, transform.position) < 0.05f)
        {
            direction=Vector3.zero;
            targetObj.SetActive(false);
        }

        //if (Vector3.Distance(transform.position, target.transform.position) > 0.05)
        //{
        //    Move(direction);
        //}
        Facing(directionTrue);
        Move(direction);
    }


    // rotate footballer to the target
    void Facing (Vector3 target)
    {
        target.y = 0;
        
        transform.rotation = Quaternion.LookRotation( Vector3.RotateTowards(transform.forward, target, rotationSpeed * Mathf.Clamp(1 - curSpeed/maxSpeed, 0, 1) * Time.deltaTime, 0));
    }

    // move footballer in desired direction, speed depends on facing
    void Move (Vector3 direction)
    {
        curSpeed = velo.magnitude;
        float dirModifier = Mathf.Lerp(roamSpeed, moveSpeed, 1 - Vector3.Angle(transform.forward, direction) / 180);

        trust = direction * accPower / physicsMass * dirModifier * Time.deltaTime;
        drag = - velo * curSpeed / maxSpeed * Time.deltaTime;

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
