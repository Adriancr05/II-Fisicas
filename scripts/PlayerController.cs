using UnityEngine;

public class PlayerController : MonoBehaviour {
  private Rigidbody rb;
  private Vector3 direction;
  public float speed = 5f;

  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;        
  }

  void FixedUpdate() {
    rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
  }
}
