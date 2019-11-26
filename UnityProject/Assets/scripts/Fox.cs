using UnityEngine;

public class Fox : MonoBehaviour
{
	/// <summary>
	/// 移動速度
	/// </summary>
	public float movespeed = 1.0f;
	[Header("FOX的TRANSFORM")]
	public Transform foxtrans;
	[Header("FOX的rigidbody")]
	public Rigidbody2D foxrigid;
	[Header("FOX的SpriteRenderer")]
	public SpriteRenderer spriteA;

	public Vector2  force = new Vector2( 2.0f,0);
	/// <summary>
	/// 移動方法
	/// </summary>
	private void Move()
	{
		float m1 = Input.GetAxisRaw("Horizontal");
		if (m1 > 0)				//如果輸入向右面向右邊
			spriteA.flipX = false;
		if(m1 < 0)				//如果輸入向左則面向左邊
			spriteA.flipX = true;


		foxtrans.position += new Vector3(m1*Time.deltaTime*movespeed, 0, 0);		 //移動

	}

	void Start()
    {
		
	}

    
    void Update()
    {

		Move();

		foxrigid.AddForce(force);  //掉落(?)

		//跳躍(?)
		if (Input.GetKeyDown(KeyCode.Space))
		{
			foxrigid.AddForce(transform.up * 10.0f, ForceMode2D.Impulse);
		}
	}
}
