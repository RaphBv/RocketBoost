using UnityEngine;

public class Booster : MonoBehaviour
{

    [SerializeField] int boosterForce = 1000;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Yess");
        Movement _player = other.GetComponent<Movement>();
        if (!_player) return;

        Rigidbody _rb = _player.Rb;
        _rb.freezeRotation = true;
        _rb.AddRelativeForce(Vector3.up * boosterForce);
        _rb.freezeRotation = false;
        Destroy(gameObject);
    }
}
