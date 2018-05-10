using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

	//小さい星の点数
	private const int smallStarPoint = 10; 
	//大きい星の点数
	private const int largeStarPoint = 50; 
	//小さい雲の点数
	private const int smallCloudPoint = 75; 
	//大きい雲の点数
	private const int largeCloudPoint = 25; 

	//得点
	private int point = 0;

	//ボールが見える可能性のあるz軸の最大値
	private float visiblePosZ = -6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;

	//得点を表示するテキスト
	private GameObject pointText;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		this.pointText = GameObject.Find("PointText");
		this.pointText.GetComponent<Text> ().text = point.ToString();
	}

	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if (this.transform.position.z < this.visiblePosZ) {
			//GameoverTextにゲームオーバを表示
			this.gameoverText.GetComponent<Text> ().text = "Game Over";
		}
		//点数の更新
		this.pointText.GetComponent<Text> ().text = point.ToString();
	}
	void OnCollisionEnter(Collision other) {

		if (other.gameObject.tag == "SmallStarTag") {//小さい星にヒット
			point += smallStarPoint;
		} else if (other.gameObject.tag == "LargeStarTag") {//大きい星にヒット
			point += largeStarPoint;
		} else if (other.gameObject.tag == "SmallCloudTag") {//小さい雲にヒット
			point += smallCloudPoint;
		} else if (other.gameObject.tag == "LargeCloudTag") {//大きい雲にヒット
			point += largeCloudPoint;
		} else {//その他

		}

	}
}