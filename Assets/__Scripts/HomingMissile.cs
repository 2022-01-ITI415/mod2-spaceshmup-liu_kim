using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class homingMissile : MonoBehaviour
    {
        public Transform target;
        public GameObject thisMissile;
        public Rigidbody2D thisMissileRB;


        public float angleChangingSpeed;
        public float movementSpeed;
      
        void FixedUpdate()
        {
            thisMissileRB=gameObject.GetComponent<Rigidbody2D>();
            target= GameObject.FindWithTag("Enemy").transform;
            try{
                thisMissile= GameObject.FindWithTag("ProjectileHero");
            }
            catch{
                print("not found");
            }
            target= GameObject.FindWithTag("Enemy").transform;


            Vector2 direction = (Vector2)target.position - (Vector2)thisMissile.transform.position;
            direction.Normalize ();
            float rotateAmount = Vector3.Cross (direction, transform.up).z;
            thisMissileRB.angularVelocity = -angleChangingSpeed * rotateAmount;
            thisMissileRB.velocity = transform.up * movementSpeed;
        }
}
