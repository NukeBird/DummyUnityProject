using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    public float rotation_speed = 90;
    Animator animator;
    Rigidbody rb;
    int speed_hash = Animator.StringToHash("Speed");
    int jump_hash = Animator.StringToHash("Jump");
    int jump_state_hash = Animator.StringToHash("Base Layer.Jump");
    //Vector3 forward_vector;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        //forward_vector = transform.rotation * Vector3.forward;
	}

    Vector3 GetForward()
    {
        return transform.worldToLocalMatrix.MultiplyVector(transform.forward);
    }
	
	// Update is called once per frame
	void Update ()
    {
        float speed = Input.GetAxis("Vertical");

        animator.SetFloat(speed_hash, speed);

        var info = animator.GetAnimatorTransitionInfo(0);

        if (Input.GetKeyDown(KeyCode.Space) && 
            info.nameHash != jump_state_hash)
        { 
            animator.SetTrigger(jump_hash);
        }
        float rotation = Input.GetAxis("Horizontal") * rotation_speed;

        //rb.velocity = forward_vector * speed * 125 * Time.smoothDeltaTime;
        rb.transform.Rotate(Vector3.up, rotation * Time.smoothDeltaTime);
        rb.transform.Translate(new Vector3(-speed * 3.5f * Time.smoothDeltaTime, 0, 0));
    }
}
