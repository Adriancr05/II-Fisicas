using UnityEngine;

public class CollisionColor : MonoBehaviour {
  void OnCollisionEnter(Collision collision) {
    if (!collision.gameObject.CompareTag("Floor")) {
      Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
      GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
    }
  }
}