using UnityEngine;
using System.Collections;

public class SpawnerMovement : MonoBehaviour {

  public Transform MinimumBoundary;
  public Transform MaxBoundary;

    public Transform WorldUpLimit;

  public float TimeForNextPosition = 3;

  public Transform Metheorite;

	// Use this for initialization
	void Start () {
    ChangePosition();
	}
	
	// Update is called once per frame
	void Update () {
	  
	}

  void ChangePosition() {
    float x = Random.Range(MinimumBoundary.position.x, MaxBoundary.position.x);
        float y = WorldUpLimit.position.y;
    Vector3 currentPosition = transform.position;
    currentPosition.x = x;
        currentPosition.y = y;
    transform.position = currentPosition;

    TimeForNextPosition *= .9f;
    TimeForNextPosition = Mathf.Clamp(TimeForNextPosition, .5f, 3);

    Instantiate(Metheorite, transform.position, Quaternion.identity);

    Invoke("ChangePosition", TimeForNextPosition);
  }
}
