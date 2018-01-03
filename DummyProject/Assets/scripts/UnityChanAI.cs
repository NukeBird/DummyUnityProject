using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanAI : MonoBehaviour
{
    Animator animator;
    public float max_wait_time = 4f;
    float wait_time = 0;
    int superwait_anim;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
        superwait_anim = Random.Range(1, 4);
    }
	
	// Update is called once per frame
	void Update()
    {
        if (animator == null)
            return;

        var current_state = animator.GetCurrentAnimatorStateInfo(0);

        if (current_state.IsName("WAIT00"))
        {
            wait_time += Time.deltaTime;

            if (wait_time > max_wait_time)
            {
                animator.Play("WAIT0" + superwait_anim.ToString());
                wait_time = 0;
                superwait_anim = (++superwait_anim - 1) % 4 + 1;
            }
        }
	}
}
