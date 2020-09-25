using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCollision : MonoBehaviour
{
    [SerializeField]
    private float moveStep = .1f;
    [SerializeField]
    private float colliderCooldown = .25f;

    private Vector3 lastFrameVelocity;
    private BoxCollider boxCollider;
    private Rigidbody rb;
    
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        lastFrameVelocity = rb.velocity;
    }

    //  consider refactoring collider on each wing instead of single big box
    //  consider refactoring to only MoveTowards center on 1 axis, ie hit on right,
    //      push ship left towards center.

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Environment")
        {
            //turn off collider so player doesnt take 1million frames of damage instantly
            rb.detectCollisions = false;

            // handle health and hit stuff here (add flash effect, etc)
            Debug.Log("hit environment object");
            transform.position = Vector3.MoveTowards(transform.position,transform.parent.position, moveStep);
            //try changing to lerp if movetowards doesnt work

            //wait, then turn collider back on
            StartCoroutine(EnableCollision());
        }
    }

    private IEnumerator EnableCollision()
    {
        Debug.Log("collider off");
        //refactor to add variable that design can mess with?
        yield return new WaitForSeconds( colliderCooldown ) ;
        Debug.Log("collider on");

        rb.detectCollisions = true ;
    }
    

}
