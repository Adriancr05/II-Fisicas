using UnityEngine;

public class ThrowBall : MonoBehaviour {
  public float speed = 5f;
  private Rigidbody rb;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.X)) {
      rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
  }
}
