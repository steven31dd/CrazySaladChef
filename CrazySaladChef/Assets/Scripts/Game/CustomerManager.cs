using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CustomerManager : MonoBehaviour
{
    [SerializeField] List<GameObject> customerCounters = new List<GameObject>();
    [SerializeField] GameObject customerPrefab;

    [SerializeField] private Vector2 randomSpawnTime;
    private float _timer = 0f;

    bool ready = false;

    bool canSpawn = false;



    public void InitCustomerManager()
    {
        ready = true;
        _timer = Random.Range(randomSpawnTime.x, randomSpawnTime.y);
    }


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            customerCounters.Add(transform.GetChild(i).gameObject);
        }
    }

    public void InitiateACustomer()
    {
        foreach(GameObject GO in customerCounters)
        {
            if(GO.GetComponent<InteractionCustomer>().GetCustomerSpotCount == 0)
            {
                GameObject newCustomer = Instantiate(customerPrefab);
                GO.GetComponent<InteractionCustomer>().SetNewCustomer(newCustomer);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready) return;

        if (canSpawn)
        {
            //Start Spawning a customer
            InitiateACustomer();
            //set a random time
            _timer = Random.Range(randomSpawnTime.x, randomSpawnTime.y);
            canSpawn = false;
        }
        else
        {
            _timer -= Time.deltaTime;

            if(_timer <= 0)
            {
                canSpawn = true;
            }
        }
    }
}
