using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidManager : MonoBehaviour
{
   public GameObject[] boids;

   public float movementSpeed = 15f;
   public float swimSpeed = 20f;

   public bool seperation = true;
   public bool alignment = true;
   public bool cohesion = true;

   void Update() {
        boids = GameObject.FindGameObjectsWithTag("Boid");

        foreach(GameObject boid in boids) {
            Boid boidScript;
            boidScript = boid.GetComponent<Boid>();

            boidScript.movementSpeed = movementSpeed;
            boidScript.swimSpeed = swimSpeed;

            if (seperation) {
                boidScript.seperation = true;
            }
            if (seperation == false) {
                boidScript.seperation = false;
            }

            if (alignment) {
                boidScript.alignment = true;
            }
            if (alignment == false) {
                boidScript.alignment = false;
            }

            if (cohesion) {
                boidScript.cohesion = true;
            }
            if (cohesion == false) {
                boidScript.cohesion = false;
            }
        }
    }
}
