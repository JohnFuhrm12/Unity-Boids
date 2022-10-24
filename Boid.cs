using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    public float movementSpeed = 15f;
    public float swimSpeed = 20f;
    public GameObject[] boidRef;

    public Vector3 Direction;

    public bool seperation = true;
    public bool alignment = true;
    public bool cohesion = true;

    void Start()
    {
        movementSpeed = 15f;
        swimSpeed = 20f;
        boidRef = GameObject.FindGameObjectsWithTag("Boid");
    }

    // Update is called once per frame
    void Update()
    {
        Flock();
        transform.position += transform.forward * swimSpeed * Time.deltaTime;
    }

    void Flock() {
        foreach(GameObject refer in boidRef) {
            float dist = Vector3.Distance(refer.transform.position, transform.position);
            Direction = (gameObject.transform.position - refer.transform.position).normalized;

        if (dist <= 50) { //Ignore if Too Far Away
            if (Physics.Linecast(transform.position, refer.transform.position)) {
                // AVOID
                if (dist < 8 && seperation) {
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, Direction, movementSpeed * Time.deltaTime, 0.0f));
                }
                // SAME DIRECTION (TO MAKE SPHERE GROUPING PATTERNS DISABLE THIS)
                if (dist > 8 && dist < 12 && alignment) {
                    transform.rotation = Quaternion.Lerp(transform.rotation, refer.transform.rotation, movementSpeed * Time.deltaTime);
                }
                // COME BACK
                if (dist >= 40 && cohesion) {
                    transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, -Direction, movementSpeed * Time.deltaTime, 0.0f));
                }
            }
        }
        }
    }
}
