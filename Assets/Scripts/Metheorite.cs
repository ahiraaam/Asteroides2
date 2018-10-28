using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Metheorite : MonoBehaviour {

  private int Life = 5;
  Text score;
    public static int puntos = 0;


    public Transform ExplosionParticleSystem;

    public GameObject item;

	// Use this for initialization
	void Start () {
        score = GameObject.Find("ScoreContador").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

  void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Bullet")
        {
            TakeDamage(other.gameObject);
        }else if(other.gameObject.tag == "BulletRoja")
        {
            TakeDamageRed(other.gameObject);
        }
  }

  void TakeDamage(GameObject bullet) {
    Destroy(bullet);
    Life--;
    gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    CancelInvoke("ResetColor");
    Invoke("ResetColor", 1);
    if (Life <= 0) {
      Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
            Instantiate(item, transform.position, Quaternion.identity);

            Destroy(gameObject);
            puntos  =puntos + 100;
            score.text = puntos.ToString();
        }
  }


    void TakeDamageRed(GameObject bullet)
    {
        Destroy(bullet);
        Life = Life-2;
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        CancelInvoke("ResetColor");
        Invoke("ResetColor", 1);
        if (Life <= 0)
        {
            Instantiate(ExplosionParticleSystem, transform.position, Quaternion.identity);
            Instantiate(item, transform.position, Quaternion.identity);

            Destroy(gameObject);
            puntos = puntos + 100;
            score.text = puntos.ToString();

        }
    }

    void ResetColor() {
    gameObject.GetComponent<Renderer>().material.color = Color.white;
  }


}
