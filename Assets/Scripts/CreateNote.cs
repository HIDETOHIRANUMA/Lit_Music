using UnityEngine;
using System.Collections;

public class CreateNote : MonoBehaviour {

	//音符オブジェクトを生成するため
	public GameObject note;

	//音符の生成位置指定用
	public Vector3 position = new Vector3(-10, 0, 0);

	private int index = 0;

	void Start()
	{
	}

	void Update () {

		//スタート時にまとめて作ったほうがカクツキが少なくなるかも
		if(Beat.timer >=  Beat.timing[index] -1)
		{
			Create();
			index++;
		}
	}

	//音符を作る関数
	public void Create()
	{
		Instantiate(note, position, this.transform.rotation);

	}
}