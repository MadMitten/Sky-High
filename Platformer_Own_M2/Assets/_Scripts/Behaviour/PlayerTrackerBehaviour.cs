using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrackerBehaviour : MonoBehaviour
{
    public float timeToHit = 5f;
    public float range = 5f;
    public float starTTL = 0.75f;
    public float starSpeed = 20f;

    Ray2D trackerRay = new Ray2D();
    bool isTracking = false;
    float timer = 5f;
    Vector2 relDirectionToPlayer;

    void FixedUpdate()
    {
        if (GameBehaviour.instance.paused == false)
        {
            RaycastHit2D rayHit;

            relDirectionToPlayer = (this.transform.position - GameObject.FindGameObjectWithTag("Player").transform.position).normalized;

            trackerRay.origin = new Vector2(transform.position.x, transform.position.y);

            trackerRay.direction = relDirectionToPlayer;

            rotateTo();
            rayHit = Physics2D.Raycast(transform.position, -relDirectionToPlayer, range);
            Debug.DrawRay(trackerRay.origin, -relDirectionToPlayer * range, Color.red);

            if (isTracking)
            {
                timer -= Time.deltaTime;
                if ((timer <= 0) && (isTracking))
                {
                    timer = timeToHit;
                    shoot();
                }
                drawToPlayer(rayHit);
            }

            if (rayHit.collider != null)
            {
                if (rayHit.collider.CompareTag("Player"))
                {
                    //Debug.Log("Distance to player is: " + rayHit.distance);
                    isTracking = true;
                }
                else
                {
                    isTracking = false;
                    timer = timeToHit;
                    //Debug.Log("No longer tracking");
                }
            }
            else
            {
                isTracking = false;
                timer = timeToHit;
            }
        }
    }

    private void drawToPlayer(RaycastHit2D hit2D)
    {
        LineRenderer line = GetComponent<LineRenderer>();
        if(line.useWorldSpace==false)
        {
            line.useWorldSpace = true;
        }
        line.SetPosition(0, this.gameObject.transform.localPosition);
        try
        {
            line.SetPosition(1, hit2D.collider.gameObject.transform.localPosition);
        } catch
        {
            line.useWorldSpace = false;
        }
    }

    void shoot()
    {
        Quaternion rot = this.transform.rotation * Quaternion.Euler(0,0,-90);
        //Debug.Log("Shoot");
        //ShootableObjects.instance.shootObject(0,this.transform.position,this.transform.rotation);
        GameObject star = ShootableObjects.instance.shootObject(0,this.transform.position,rot);
        StarBehaviour sb = star.GetComponent<StarBehaviour>();
        sb.ttl = starTTL;
        sb.speed = starSpeed;
    }

    void rotateTo()
    {
        Vector3 difference = GameObject.FindGameObjectWithTag("Player").transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }


}
