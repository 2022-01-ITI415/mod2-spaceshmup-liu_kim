using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
    {
        public GameObject target;
        public GameObject thisMissile;
        public Rigidbody thisMissileRB;
        public GameObject[] enemiesArray;
        public GameObject[] projectileArray;
        public GameObject[] missilesArray;
        public GameObject closest;
        public Vector3 CurrPosition;
        public Vector3 diff;
        public Vector3 direction;
        public int missileCounter=0;
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
            //destroy extra missiles
            projectileArray=GameObject.FindGameObjectsWithTag("ProjectileHero");
            print(projectileArray.Length);
            missileCounter=0;
            foreach (GameObject go in projectileArray){
                if (go.GetComponent<MissileScript>() != null){
                    missileCounter+=1;
                }
                if (missileCounter>4){
                    go.SetActive(false);
                    missileCounter-=1;
                }
            }

            thisMissile=gameObject;
            // get nearest enemy 
            target=FindClosestTarget("Enemy");
            print(target);

            if (target != null)
            {
                targetEnemy();
            }
        }

        void targetEnemy()
        {
            print(thisMissile);
            thisMissileRB=thisMissile.GetComponent<Rigidbody>();
            if (GameObject.FindWithTag("Enemy")==null){
                thisMissileRB.AddForce(0,20,0);
            }


            direction = target.transform.position - thisMissile.transform.position;
            direction.Normalize ();
            print(direction);

		    Vector3 rotateAmount = Vector3.Cross(direction, thisMissile.transform.position);            
            thisMissileRB.angularVelocity = -rotateAmount*5;
            thisMissileRB.velocity = transform.up * 5;
            
 

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

