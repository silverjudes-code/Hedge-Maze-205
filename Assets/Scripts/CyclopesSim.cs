using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CycloipesSim : MonoBehaviour
{
    //Rigidbody capsule;
    public float explosionForce = 1000f;
    public float explosionRadius = 50f;
    public float upwardsModifier = 5f;
    //public Vector3 explosionPOS;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) //left mouse = 0, right mouse = 1, middle mouse = 2
        
            //send laser into scene
            Ray laser = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit laserImpactReport = new RaycastHit(); //class

            if (Input.GetMouseButtonDown(0) && Physics.Raycast(laser, out laserImpactReport))//can send additional information if needed
            {
                Destroy(laserImpactReport.transform.gameObject);

                Debug.Log("Kill confirmed.");
            }
        if (Input.GetMouseButtonDown(1) && Physics.Raycast(laser, out laserImpactReport))//can send additional information if needed
        {
            laserImpactReport.rigidbody.AddExplosionForce(explosionForce, laserImpactReport.point, explosionRadius, upwardsModifier);
                       
            Debug.Log("Kill confirmed.");
        }
    }
}