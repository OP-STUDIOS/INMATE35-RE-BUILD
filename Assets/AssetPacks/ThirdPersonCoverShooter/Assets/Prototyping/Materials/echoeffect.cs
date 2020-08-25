using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class echoeffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    public GameObject itemObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       // if ( != 0)
        {
            if (timeBtwSpawns <= 0) {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                Destroy(instance, 8f);
                timeBtwSpawns = startTimeBtwSpawns;

            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    } }
