using UnityEngine;

[ExecuteInEditMode]
public class Spin : MonoBehaviour{

	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);
	Transform mTrans;

	void Start (){
		mTrans = transform;
	}

	void Update (){
		ApplyDelta(Time.deltaTime);
	}

	public void ApplyDelta (float delta) {
		delta *= Mathf.Rad2Deg * Mathf.PI * 2f;
		Quaternion offset = Quaternion.Euler(rotationsPerSecond * delta);
		mTrans.rotation = mTrans.rotation * offset;
	}
}