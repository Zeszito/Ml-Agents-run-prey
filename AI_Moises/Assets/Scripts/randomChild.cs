using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomChild : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> myChilds;

    void Start()
    {

     

     
 

        foreach (GameObject item in myChilds)
        {
            item.transform.localPosition = new Vector3(Random.Range(-10, 10), item.transform.localPosition.y, Random.Range(-10, 10));
            item.transform.rotation = Quaternion.Euler( 0, Random.Range(0,360), 0);

        }


    }


}
