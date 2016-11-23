using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour {
	public KeyCode upKey;
	public KeyCode downKey;
	public KeyCode leftKey;
	public KeyCode rightKey;

	public float speed = 16;
	public GameObject wallPrefab;

	Collider2D wall;
	Vector2 lastWall;
	// Use this for initialization
	void Start () {

		GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
		spawnWall();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(upKey)) {
			GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
			spawnWall();
		}
		else if (Input.GetKeyDown(downKey)) {
			GetComponent<Rigidbody2D>().velocity = -Vector2.up * speed;
			spawnWall();
		}
		else if (Input.GetKeyDown(rightKey)) {
			GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
			spawnWall();
		}
		else if (Input.GetKeyDown(leftKey)) {
			GetComponent<Rigidbody2D>().velocity = -Vector2.right * speed;
			spawnWall();
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			if (Time.timeScale == 1.0F)
				Time.timeScale = 0.7F;
			else
				Time.timeScale = 1.0F;
			Time.fixedDeltaTime = 0.02F * Time.timeScale;
		}

		fitColliderBetween(wall, lastWall, transform.position);
	}
	void fitColliderBetween(Collider2D collision, Vector2 a, Vector2 b) {
		
		collision.transform.position = a + (b - a) * 0.5f;

		float dist = Vector2.Distance(a, b);
		if (a.x != b.x)
			collision.transform.localScale = new Vector2(dist + 1, 1);
		else
			collision.transform.localScale = new Vector2(1, dist + 1);
	}

	void spawnWall()
	{
		lastWall = transform.position;

		GameObject g = (GameObject)Instantiate(wallPrefab, transform.position, Quaternion.identity);
		wall = g.GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co != wall) {
			if (this.tag == "Player2") {
				Destroy (gameObject);
				print ("Player 1 Won");
				Console.WriteLine("Made By Eraj Sattori");
				Application.LoadLevel ("Player1win");
			} else if (this.tag == "Player") {
				Destroy (gameObject);
				print ("Player 2 won");
				Console.WriteLine("Made By Eraj Sattori");
				Application.LoadLevel ("Player2win");
			}
		}
	}
}