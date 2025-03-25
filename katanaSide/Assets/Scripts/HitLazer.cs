using UnityEngine;

public class HitLazer : MonoBehaviour
{
	float Speed = 50f;
	Vector2 MousePos;
	Transform tr;
	Vector3 dir;

	float angle;
	Vector3 dirNo;

	void Start()
	{
		tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		MousePos = Input.mousePosition;
		MousePos = Camera.main.ScreenToWorldPoint(MousePos);
		Vector3 Pos = new Vector3(MousePos.x, MousePos.y, 0);
		dir = Pos - tr.position;                //���콺 - �÷��̾� ������ ���� ���콺�� �ٶ󺸴� ����

		//�ٶ󺸴� ���� ���ϱ�
		angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

		//normalized ���� ����
		dirNo = new Vector3(dir.x, dir.y, 0).normalized;

		Destroy(gameObject, 4f);
	}

	// Update is called once per frame
	void Update()
	{
		transform.rotation = Quaternion.Euler(0f, 0f, angle);
		transform.position += dirNo * Speed * Time.deltaTime;
	}
}
