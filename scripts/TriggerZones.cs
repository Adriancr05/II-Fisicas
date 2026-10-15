using UnityEngine;

public class TriggerZones : MonoBehaviour {
  private Renderer renderer;
  private Color original_color;
  public int damage = 0;

  void Start() {
    renderer = GetComponent<Renderer>();
    original_color = renderer.material.color;
  }

  private void OnTriggerEnter(Collider collider) {
    if (collider.CompareTag("ColorZone")) {
      renderer.material.color = Color.orange;
    }

    if (collider.CompareTag("DamageZone")) {
      damage += 10;
      Debug.Log("You entered the damage zone. Total damage: " + damage);
    }
  }
  private void OnTriggerExit(Collider collider) {
    if (collider.CompareTag("ColorZone")) {
      renderer.material.color = original_color;
    }
  }
}
