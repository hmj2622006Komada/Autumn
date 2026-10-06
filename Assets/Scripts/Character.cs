using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
	
	public float minX = -8.0f;
	public float maxX = 8.0f;

	void Start()
	{
		Application.targetFrameRate = 60;
	}

	void Update()
	{
		// 現在地を取得
		Vector3 pos = transform.position;

		// キー入力に応じて位置を変更
		if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
		{
			pos.x -= 2.0f;  // 左に「2」動かす
		}
		if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
		{
			pos.x += 2.0f;  // 右に「2」動かす
		}

		pos.x = Mathf.Clamp(pos.x, minX, maxX);

		transform.position = pos;
	}
}