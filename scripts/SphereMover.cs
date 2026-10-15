using UnityEngine;

public class SphereMover : MonoBehaviour {
  public Transform cylinder;
  public Transform cube;
  public float speed = 5f;
  private bool is_changed = false;

  void Update() {
    transform.LookAt(cylinder);
    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    if (!is_changed && Vector3.Distance(transform.position, cube.position) < 1f) {
      cube.GetComponent<Renderer>().material.color = Color.orange;
      is_changed = true;
    }
  }
}
