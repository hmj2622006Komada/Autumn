using UnityEngine;
using UnityEngine.SceneManagement;

public class nmomiji : MonoBehaviour
{
	[Header("落下設定")]
	[Tooltip("落下のスピード")]
	public float fallSpeed = 3.0f;

	[Header("揺れの設定")]
	[Tooltip("左右に揺れる幅（振幅）")]
	public float swayWidth = 1.0f;
	[Tooltip("揺れる速さ（周波数）")]
	public float swaySpeed = 4.0f;

	[Header("当たり判定の設定")]
	[Tooltip("接触したときに消滅する対象のタグ名")]
	public string targetTag = "Player"; // インスペクターから変更できるように変数化しました

	private float startX;

	void Start()
	{
		// 初期位置のX座標を記録
		startX = transform.position.x;
	}

	void Update()
	{
		// 下方向へ移動
		Vector3 pos = transform.position;
		pos.y -= fallSpeed * Time.deltaTime;

		// サイン波を使って左右の揺れを計算
		pos.x = startX + Mathf.Sin(Time.time * swaySpeed) * swayWidth;

		// 位置を更新
		transform.position = pos;
		if (transform.position.y < -6)
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("targetTag"))
		{
			HitAction();
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("targetTag"))
		{
			HitAction();
		}
	}

	void HitAction()
	{
		SceneManager.LoadScene("NextScene");

		Destroy(gameObject);
	}
}