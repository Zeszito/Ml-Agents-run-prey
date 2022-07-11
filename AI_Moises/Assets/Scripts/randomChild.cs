using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomChild : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> myChilds;
    public Collider predador;

    void Start()
    {


        RandomPOS();


    }

    public void RandomPOS()
    {
        foreach (GameObject item in myChilds)
        {
            item.SetActive(true);
            int rdn = Random.Range(1, 5);

            if (rdn == 1)
            {
                item.transform.localPosition = new Vector3(Random.Range(-10, 2), item.transform.localPosition.y, Random.Range(-10, 2));
            };

            if (rdn == 2)
            {
                item.transform.localPosition = new Vector3(Random.Range(2, 10), item.transform.localPosition.y, Random.Range(2, 10));
            };
            if (rdn == 3)
            {
                item.transform.localPosition = new Vector3(Random.Range(-10, 2), item.transform.localPosition.y, Random.Range(2, 10));
            };

            if (rdn == 4)
            {
                item.transform.localPosition = new Vector3(Random.Range(2, 10), item.transform.localPosition.y, Random.Range(-10, 2));
            };
            item.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
       
         

        }
    }


}
