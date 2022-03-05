using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleScript : MonoBehaviour
    {
        public Transform target;
        public GameObject thisMissile;
        public Rigidbody thisMissileRB;


        public float angleChangingSpeed;
        public float movementSpeed;
      
        void FixedUpdate()
        {
            thisMissileRB=gameObject.GetComponent<Rigidbody>();
            target= GameObject.FindWithTag("Enemy").transform;
            try{
                thisMissile= GameObject.FindWithTag("ProjectileHero");
            }
            catch{
                print("not found");
            }
            target= GameObject.FindWithTag("Enemy").transform;


            Vector3 direction = target.position - thisMissile.transform.position;
            direction.Normalize ();
            // float rotateAmount = Vector3.Cross (direction, transform.up).z;
            // thisMissileRB.angularVelocity = -angleChangingSpeed * rotateAmount;
            // thisMissileRB.velocity = transform.up * movementSpeed;
            thisMissileRB.velocity = target.position-thisMissile.transform.position;
            thisMissileRB.AddForce(target.position-thisMissile.transform.position);
            thisMissileRB.velocity*=3;
            print(thisMissileRB.velocity);
        }
}
