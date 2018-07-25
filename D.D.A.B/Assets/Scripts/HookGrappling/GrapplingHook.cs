using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour {

    DistanceJoint2D joint;
    Vector3 targetPos;
    RaycastHit2D hit;
    public float distance = 10f;
    public LayerMask mask;
    public LineRenderer line;
    public float step = 0.5f;
    public bool once;


	void Awake () {
        joint = GetComponent<DistanceJoint2D>();
        joint.enabled = false;
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (joint.distance > 0.1f)
        {
            joint.distance -= step * Time.deltaTime;
        }
        else
        {
            line.enabled = false;
            joint.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            
            targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            hit = Physics2D.Raycast(transform.position, targetPos - transform.position, distance, mask);

            if(hit.collider != null && hit.collider.gameObject.GetComponent<Rigidbody2D>())
            {
                once = true;
                joint.enabled = true;
                Vector2 connectPoint = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                connectPoint.x = connectPoint.x / hit.collider.transform.localScale.x;
                connectPoint.y = connectPoint.y / hit.collider.transform.localScale.y;
                joint.connectedAnchor = connectPoint;

                joint.connectedBody = hit.collider.gameObject.GetComponent<Rigidbody2D>();
                //joint.connectedAnchor = hit.point - new Vector2(hit.collider.transform.position.x, hit.collider.transform.position.y);
                joint.distance = Vector2.Distance(transform.position, hit.point);

                line.enabled = true;

                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);

                line.GetComponent<RopeRatio>().grabPos = hit.point;
            }
        }
        if(once)
        {
            line.SetPosition(1, joint.connectedBody.transform.TransformPoint(joint.connectedAnchor));
        }

        if (Input.GetKey(KeyCode.Q))
        {
            line.SetPosition(0, transform.position);
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            joint.enabled = false;
            line.enabled = false;

        }
	}
}
