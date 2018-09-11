using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{
    [SerializeField]
    Rigidbody body;

    float theta, phi, cooldown;

    [SerializeField]
    float pushOffForce;

    [SerializeField]
    GameObject myo;
   
    //Biggins's
    int numentered= 0;
    ThalmicMyo tm;

	// Use this for initialization
	void Start ()
    {
        tm = myo.GetComponent<ThalmicMyo>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        float w = transform.rotation.w;
        float x = transform.rotation.x;
        float y = transform.rotation.y;
        float z = transform.rotation.z;

        // -180 --> 180
        float yaw = Mathf.Atan2(2 * y * w - 2 * x * z, 1 - 2 * y * y - 2 * z * z);
        // -90 --> 90
        float pitch = Mathf.Atan2(2 * x * w - 2 * y * z, 1 - 2 * x * x - 2 * z * z);

        theta = -pitch + Mathf.PI / 2;
        phi = yaw + Mathf.PI;
        
        //Debug.DrawRay(transform.parent.parent.transform.position, new Vector3(Mathf.Sin(theta) * Mathf.Sin(phi), Mathf.Cos(theta), Mathf.Sin(theta) * Mathf.Cos(phi)), Color.magenta, Time.deltaTime);

        cooldown += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Checkpoint");
        numentered++;
    }

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space) || tm.pose == Thalmic.Myo.Pose.DoubleTap)
        {
            if (cooldown < 1)
            {
                return;
            }

            Vector3 pushOff = new Vector3(Mathf.Sin(theta) * Mathf.Sin(phi), Mathf.Cos(theta), Mathf.Sin(theta) * Mathf.Cos(phi)) * pushOffForce;
            body.AddForce(pushOff, ForceMode.Impulse);
            if (other.attachedRigidbody)
            {
                other.attachedRigidbody.AddForce(-pushOff, ForceMode.Impulse);
            }
            cooldown = 0;
        }
        else if (Input.GetKey(KeyCode.LeftShift) || tm.pose == Thalmic.Myo.Pose.Fist)
        {
            body.velocity = Vector3.Lerp(body.velocity, Vector3.zero, 0.1f);
            body.angularVelocity = Vector3.Lerp(body.angularVelocity, Vector3.zero, 0.1f);
        }
    }
    private void OnGUI()
    {
        GUI.Box(new Rect(10, 40, 50, 20), "" + numentered);
    }
}
