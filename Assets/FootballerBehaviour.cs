using UnityEngine;
using System.Collections;

public class FootballerBehaviour : MonoBehaviour
{

    float moveSpeed = 8;
    float roamSpeed = 1f;
    float rotationSpeed = 3;
    GameObject Target;

    // Use this for initialization
    void Start ()
    {
        Target = GameObject.Find("Target");
	}
	
	// Update is called once per frame
	void Update ()
    {
        Facing(Target.transform.position);

        if (Vector3.Distance(transform.position, Target.transform.position) > 0.01)
        {
            Move(Target.transform.position);
        }
	}

    void AvoidCollision ()
    {

    }

    // rotate footballer to the target
    void Facing (Vector3 target)
    {
        target = target - transform.position;
        target.y = 0;
        
        transform.rotation = Quaternion.LookRotation( Vector3.RotateTowards(transform.forward, target, rotationSpeed * Time.deltaTime, 0));
    }

    // move footballer in desired direction, speed depends on facing
    void Move (Vector3 direction)
    {
        direction = direction - transform.position;

        float speedModifier = Mathf.Lerp(roamSpeed, moveSpeed, 1 - Vector3.Angle(transform.forward, direction) / 180);

        transform.Translate(direction.normalized * speedModifier * Time.deltaTime, Space.World);
        Debug.DrawRay(transform.position, direction.normalized, Color.red);
    }
}
