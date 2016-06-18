using UnityEngine;
using System.Collections;

public class Beat : MonoBehaviour {

	//本番作品では、なるべくstatic変数を使わないこと。
	//ゲームのタイマーを宣言。
	public static float timer;
	//曲のタイミングデータを宣言
	public static float[] timing;
	//音符のインデックスを宣言。
	private int indexTiming;
	//曲の判定結果を格納しておく変数を宣言。
	public static int cool; public static int good; public static int bad;

	//エフェクトを格納。
	public GameObject goodEffect;
	public GameObject badEffect;

	//開始時
	void Start () {

		//タイミングデータはDTMを見ながら作成した。
		timing = new float[] {1.495f,2.220f,2.580f,2.942f,3.664f,4.387f,4.749f,5.110f,5.472f,5.833f,6.556f,7.279f,7.818f,8.363f,8.725f,9.267f,9.809f,10.170f,10.713f,11.255f,11.616f,11.797f,11.978f,12.158f,12,339f,1000f};
		cool = 0; good = 0;bad = 0;indexTiming = 0;timer = 0; 	
	}

	void Update () {

		if (IsBeat())
			checkTiming();
		//音符がヒットバーより後ろに流れたときの処理
		else if (timer - timing[indexTiming] >= 0.12f)
		{
			addBad();
			indexTiming++;
			Instantiate(badEffect, transform.position, transform.rotation);
		}

		timer += Time.deltaTime;
	}

	//スペースキーで入力。
	public bool IsBeat()
	{
		if (Input.GetKeyDown(KeyCode.Space))
			return true;
		else
			return false;
	}

	//入力とタイミングデータの比較を行い、スコアを計上していく。
	public void checkTiming()
	{

		//タイミング誤差の範囲についてはいったんpublicにしてテストしやすくしたほうがいいかも
		if(timer - timing[indexTiming] >= -0.10f && timer - timing[indexTiming] <= 0.10f)
		{
			addCool();
			indexTiming++;
			Instantiate(goodEffect, transform.position, transform.rotation);
		}
		else if(timer - timing[indexTiming] >= -0.12f && timer - timing[indexTiming] <= 0.12f)
		{
			addGood();
			indexTiming++;
			Instantiate(goodEffect, transform.position, transform.rotation);

		}
		else if(timer - timing[indexTiming] >= -0.6f && timer - timing[indexTiming] <= 0.6f)
		{
			addBad();
			indexTiming++;
			Instantiate(badEffect, transform.position, transform.rotation);

		}
		else
		{
			//何もしません。
		}

		//デバッグログ用
		//outputResult();
	}

	//結果の追加
	public void addCool(){cool++;}
	public void addGood(){good++;}
	public void addBad(){bad++;}

	//デバッグログに結果の出力
	//public void outputResult()
	//{
	//    Debug.Log("cool=" + cool + "\t" + "good=" + good + "\t" + "bad=" + bad + "\n");
	//}
}