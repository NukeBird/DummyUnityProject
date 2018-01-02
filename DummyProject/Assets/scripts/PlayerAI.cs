using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : MonoBehaviour
{
    private Animator animator;
    private float wait_time = 0;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        var current_state = animator.GetCurrentAnimatorStateInfo(0);

        if (current_state.IsName("WAIT00"))
        {
            wait_time += Time.deltaTime;

            if (wait_time > 4)
            {
                animator.Play("WAIT0" + Random.Range(1, 4).ToString());
                wait_time = 0;
            }
        }
	}
}
