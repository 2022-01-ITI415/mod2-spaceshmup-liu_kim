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
        public Vector3 direction;

       // public Vector3 direction;

        public float curDistance;
        public float distance;

        public float angleChangingSpeed;
        public float movementSpeed;
        public float rotateAmount;

        void Start(){
            // thisMissile=GameObject.Find("HomingMissile");
            //InvokeRepeating("targetEnemy",.0001f,.0001f);
        }

        void FixedUpdate(){
            thisMissile=gameObject;
            targetEnemy();
        }

        void targetEnemy()
        {
            //thisMissile=GameObject.Find("HomingMissile");
            print(thisMissile);
            thisMissileRB=thisMissile.GetComponent<Rigidbody>();
            if (GameObject.FindWithTag("Enemy")==null){
                thisMissileRB.AddForce(0,20,0);
            }

            // get nearest enemy 

            target=FindClosestTarget("Enemy");
            print(target);

            try{
                thisMissile=GameObject.Find("HomingMissile");
            }
            catch{
                print("projectile not found");
            }
            if (target== null || thisMissile== null){
                return;
            }

           // print(target);
            
            direction = target.transform.position - thisMissile.transform.position;
            direction.Normalize ();
            print(direction);
		    // Vector3 rotateAmount = Vector3.Cross(direction, thisMissile.transform.position);            
            // thisMissileRB.angularVelocity = -rotateAmount*25;
            // //thisMissileRB.velocity = transform.up * 5;
            
 

            //thisMissileRB.velocity= Vector3.ClampMagnitude(thisMissileRB.velocity, 25);


           // thisMissileRB.velocity=Vector3.Lerp(thisMissile.transform.position, target.transform.position, 1f); 
   
            thisMissileRB.velocity += direction;
            thisMissileRB.AddForce(direction);
            thisMissile.transform.position += direction;
  
            print(thisMissileRB.velocity);
            
            //reset target
            target= null;
        }
        
        GameObject FindClosestTarget(string trgt) 
            {
                enemiesArray= GameObject.FindGameObjectsWithTag(trgt);
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
