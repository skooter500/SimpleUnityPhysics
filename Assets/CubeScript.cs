using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

    public float speed;
    Vector3 gravity = new Vector3(0.0f, -9.8f, 0.0f);
    Vector3 velocity = Vector3.zero;
    Vector3 force = Vector3.zero;
    public float mass = 1.0f;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        float newtons = 100.0f;
        float angularVelocity = 360;

        if (Input.GetKey(KeyCode.Space))
        {
            force += Vector3.up * 1000;
        }

        if (Input.GetKey(KeyCode.A))
        {
            force -= transform.right * newtons;
        }
        if (Input.GetKey(KeyCode.D))
        {
            force += transform.right * newtons;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, angularVelocity * - Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, angularVelocity  * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            force += transform.forward * newtons;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            force -= transform.forward * newtons;
        }
        Debug.Log(transform.forward);
        Vector3 acceleration = force / mass;

        if (pos.y - 0.5f > 0)
        {
            acceleration += gravity;
        }
        else
        {
            velocity.y = 0;
            pos.y = 0.5f;
        }

        velocity += acceleration * Time.deltaTime;
        
        velocity = Vector3.ClampMagnitude(velocity, 5);
        velocity *= 0.99f;

        pos += velocity * Time.deltaTime;
        transform.position = pos;
        force = Vector3.zero;
	}
}
