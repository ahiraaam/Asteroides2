using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Ship : MonoBehaviour {

  public bool damage = false;

  public Transform SpawnBulletPosition;

  public Transform Bullet;

    public Transform BulletRoja;

  public GameObject ShipMesh;

    public bool cambioDeArma = false;

    public static int score;

    Text vidaText;
    public Text scoreText;
    public static int vida = 100;

	// Use this for initialization
	void Start () {
        vidaText = GameObject.Find("VidaContador").GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            cambioDeArma = true;
        }
    }
    // Update is called once per frame
    void LateUpdate() {

        if (Input.GetKeyDown(KeyCode.Space) && cambioDeArma == false) {
            Shoot();
        } else if (Input.GetKeyDown(KeyCode.Space) && cambioDeArma == true)
        {
            ShootRojo();
        }
    }
      void Shoot() {
            
        Instantiate(Bullet, SpawnBulletPosition.position, Quaternion.identity);
      }

       void ShootRojo()
        {
            Instantiate(BulletRoja, SpawnBulletPosition.position, Quaternion.identity);

        }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Metheorite") {
            Damaged();
            vida = vida -5;
            vidaText.text = vida.ToString();

        }
        if (other.gameObject.tag == "Item")
        {
            vida = 100;
            vidaText.text = vida.ToString();

            score = int.Parse(scoreText.text);
            score += 10;

            scoreText.text = score.ToString();

            Destroy(other.gameObject);
            //Debug.Log(score);
                
            //Debug.Log("Hola");
        }
    }


  void Damaged() {
    if (damage) {
      return;
    }
    damage = true;
    ShipMesh.GetComponent<Renderer>().material.color = Color.red;
    Invoke("NotDamaged", 2);
  }

  void NotDamaged() {
    damage = false;
    ShipMesh.GetComponent<Renderer>().material.color = Color.white;
  }
}
