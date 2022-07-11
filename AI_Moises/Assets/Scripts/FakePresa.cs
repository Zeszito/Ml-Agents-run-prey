using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePresa : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 dir;
    Rigidbody rg;
    public bool human = false;
    public int mul = 20;
    void Start()
    {
        switch (Random.Range(0, 4))
        {
            case 0:
                dir = Vector3.forward;
                break;
            case 1:
                dir = -Vector3.forward;
                break;
            case 2:
                dir = Vector3.right;
                break;
            case 3:
                dir = Vector3.left;
                break;
        }
       
       rg = this.GetComponent<Rigidbody>();
       this.transform.localPosition = new Vector3(Random.Range(-10, 10), this.transform.localPosition.y, Random.Range(-10, 10));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!human)
        {
            rg.AddForce(dir * mul);
            if ((((int)Time.fixedTime) % 5) == 0)
            {
                dir = -dir;
            }
        }
        else
        {
            float cB = -Input.GetAxisRaw("Horizontal");
            float ca = -Input.GetAxisRaw("Vertical");
            dir = (Vector3.forward * ca) + (Vector3.right * cB);
            rg.AddForce(dir * mul);
        }
    
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Obestaculo" || collision.gameObject.tag == "wall")
        {
            switch (Random.Range(0, 4))
            {
                case 0:
                    dir = Vector3.forward;
                    break;
                case 1:
                    dir = -Vector3.forward;
                    break;
                case 2:
                    dir = Vector3.right;
                    break;
                case 3:
                    dir = Vector3.left;
                    break;
            }
        }
  
    }
}
