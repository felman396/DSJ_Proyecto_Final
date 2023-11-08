
using UnityEngine;

public class Ball : MonoBehaviour
{
	[HideInInspector] public Rigidbody2D rb;
	[HideInInspector] public CircleCollider2D col;

	[HideInInspector] public Vector3 pos { get { return transform.position; } }

	private bool hasEnteredVaso = false;

	void Awake ()
	{
		rb = GetComponent<Rigidbody2D> ();
		col = GetComponent<CircleCollider2D> ();
	}

	public void Push (Vector2 force)
	{
		rb.AddForce (force, ForceMode2D.Impulse);
		hasEnteredVaso = false;
	}

	public void ActivateRb ()
	{
		rb.isKinematic = false;
	}

	public void DesactivateRb ()
	{
		rb.velocity = Vector3.zero;
		rb.angularVelocity = 0f;
		rb.isKinematic = true;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Vaso") && !hasEnteredVaso) 
		{
			GameManager.Instance.IncreaseScore(1); // Incrementa el puntaje por ejemplo en 1 punto.
			hasEnteredVaso = true;
		}
	}
	
}
