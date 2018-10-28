using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {
    public float Speed;
    public float stop;
    public float start;
    private Transform target; //player

    public GameObject BulletEmissor;
    public GameObject Bala;
    private int Life = 10;

    private bool damage = false;

    public GameObject ShipMesh;

    //public GameObject camara;


    public GameObject ExplosionParticleSystem;

    // Use this for initialization
    void Start()
    {

        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        //startingDistance = camara.transform.position.y;
        //stoppingDistance = target.transform.position.y + 10;
        InvokeRepeating("Shoot", 0, 3);

    }

    // Update is called once per frame
    void Update()
    {

        if (Vector3.Distance(transform.position, target.position) < 10  && Vector3.Distance(transform.position, target.position) > -5)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);

        }



    }

    void Shoot()
    {
        Instantiate(Bala, BulletEmissor.transform.position, Quaternion.identity);
    }
}
