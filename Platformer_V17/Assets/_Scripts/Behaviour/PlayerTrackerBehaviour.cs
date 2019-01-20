using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackerBehaviour : MonoBehaviour
{
    public float timeToHit = 5f;
    public float range = 5f;
    Ray2D trackerRay;
    bool isTracking = false;
    float timer = 5f;

    void FixedUpdate()
    {
        RaycastHit2D rayHit;
        Vector2 relDirectionToPlayer = (this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;
        trackerRay.origin = new Vector2(transform.position.x, transform.position.y);
        trackerRay.direction = relDirectionToPlayer;
        rayHit = Physics2D.Raycast(transform.position, -relDirectionToPlayer,range);
        Debug.DrawRay(trackerRay.origin, -relDirectionToPlayer*range, Color.red);
        if(isTracking)
        {
            timer -= Time.deltaTime;
            if(timer<=0)
            {
                timer = timeToHit;
                Debug.Log("Hit player");
            }
           // Debug.Log("Strike Timer: " + timer);
        }
        if (rayHit.collider != null)
        {
            if(rayHit.collider.CompareTag("Player"))
            {
                //Debug.Log("Tracking...");
                isTracking = true;
            }
            else
            {
                isTracking = false;
                timer = timeToHit;
            }
        }
    }
}
