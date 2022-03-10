using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissleScript : MonoBehaviour
    {
        public GameObject target=null;
        public GameObject thisMissile;
        public Rigidbody thisMissileRB;
        public GameObject[] enemiesArray;
        public GameObject closest;
        public Vector3 CurrPosition;
        public Vector3 diff;
        public float curDistance;
        public float distance;

        // public float angleChangingSpeed;
        // public float movementSpeed;

        void Start(){
            //InvokeRepeating("targetEnemy",.0001f,.0001f);
        }

        void FixedUpdate(){
            targetEnemy();
        }

        void targetEnemy()
        {
            thisMissile=gameObject;
            thisMissileRB=gameObject.GetComponent<Rigidbody>();
            if (GameObject.FindWithTag("Enemy")==null){
                thisMissileRB.AddForce(0,20,0);
            }

            // get nearest enemy 

            target=FindClosestTarget("Enemy");

            try{
                thisMissile= GameObject.FindWithTag("ProjectileHero");
            }
            catch{
                print("projectile not found");
            }
           


            Vector3 direction = target.transform.position - thisMissile.transform.position;
            direction.Normalize ();
            // rotateAmount = Vector3.Cross (direction, transform.up).z;
            // thisMissileRB.angularVelocity = -angleChangingSpeed * rotateAmount;
            // thisMissileRB.velocity = transform.up * movementSpeed;
            
            // thisMissileRB.velocity += direction;
            // thisMissileRB.AddForce(direction);
 

            Vector3.Lerp(thisMissile.transform.position, target.transform.position, .5f); 
            thisMissile.transform.position += direction;
        
            print(thisMissileRB.velocity);


        }
        
        GameObject FindClosestTarget(string trgt) 
            {
                enemiesArray= GameObject.FindGameObjectsWithTag(trgt);
                print(enemiesArray);
                closest=null;
                distance = Mathf.Infinity;
                CurrPosition = thisMissile.transform.position;
                foreach (GameObject go in enemiesArray) {
                    diff = go.transform.position - CurrPosition;
                    curDistance = diff.sqrMagnitude;
                    if (curDistance < distance) {
                        closest = go;
                        distance = curDistance;
                    }
                }
         return closest;
     }
    //
}
