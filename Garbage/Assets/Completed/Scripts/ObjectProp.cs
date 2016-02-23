using UnityEngine;
using System.Collections;

public class ObjectProp : MonoBehaviour {

    public float explosionStrength;
    public float minRandMass;
    public float maxRandMass;

    private Vector3 forceVec;
    private Rigidbody2D rb2D;
    private ObjectVariables objectVar;
    

	// Use this for initialization
	void Start () {
        objectVar = transform.parent.gameObject.GetComponent<ObjectVariables>();
        rb2D = transform.parent.gameObject.GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void FixedUpdate(){
        
    }

   /*void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Scream")
        {
            tougness++;
            if (tougness == objectVar.tougness)
            {
                rb2D.isKinematic = false;
                Debug.Log(objectVar.objName + " Destroyed!");
            }
        }
    }*/

    void OnTriggerStay2D(Collider2D col)
    {

        if(col.tag == "Scream")
        {
            objectVar.force++;
            if (objectVar.used)
            {
                //rb2D.isKinematic = false;

                // Scream adds force to the object, useful for moving objects or very basic destruction
                /*if(GameObject.FindGameObjectWithTag("Player").transform.position.x < transform.position.x)
                {
                    rb2D.AddRelativeForce(Vector2.right * Random.Range(minRandMass, maxRandMass));
                    Debug.Log(objectVar.objName + " Falling!!!");
                }
                else if(GameObject.FindGameObjectWithTag("Player").transform.position.x > transform.position.x)
                {
                    rb2D.AddRelativeForce(Vector2.left * Random.Range(minRandMass, maxRandMass));
                    Debug.Log(objectVar.objName + " Falling!!!");
                }*/

            }

        }
    }

   /* void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Scream")
        {
            tougness++;
            if (tougness == objectVar.tougness)
            {
                rb2D.isKinematic = false;
                Debug.Log(objectVar.objName + " Destroyed!");
            }
        }
    }*/

}
