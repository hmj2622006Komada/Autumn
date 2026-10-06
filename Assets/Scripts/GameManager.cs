using UnityEngine;

public class GameManager : MonoBehaviour

{
	public GameObject momijiPrefab;

	public float spawnInterval = 1f;

	
	public float minX = -8.0f;
	public float maxX = 8.0f;
	public float spawnY = 6.0f;

	private float timer = 0f;

	void Update()
	{
		// タイマーを進める
		timer += Time.deltaTime;

		// 指定した時間が経ったら生成
		if (timer >= spawnInterval)
		{
			SpawnMomiji();
			timer = 0f; // タイマーをリセット
		}
	}

	void SpawnMomiji()
	{
		if (momijiPrefab == null)
		{
			Debug.LogWarning("もみじのプレハブが設定されていません！");
			return;
		}

		// 左右の範囲内でランダムなX座標を決める
		float randomX = Random.Range(minX, maxX);
		Vector3 spawnPosition = new Vector3(randomX, spawnY, 0f);

		// 指定した位置にもみじを生成する
		Instantiate(momijiPrefab, spawnPosition, Quaternion.identity);
	}
}

