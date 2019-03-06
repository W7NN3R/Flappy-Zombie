using UnityEngine;
using System.Collections;

public class Rock : Object {

    [SerializeField] Vector3 topPosition;
    [SerializeField] Vector3 bottomPosition;
	[SerializeField] float speed;

	// Use this for initialization
	void Start () {
		StartCoroutine (Move (bottomPosition));
	}

	protected override void Update() {
        if (gameManager.instance.PlayerActive)
        {
            base.Update();
        }        
	}

	IEnumerator Move(Vector3 target) {
        if (topPosition.y == 0 && topPosition == null)
        {
            topPosition.y = 2f;
        }
        if (bottomPosition.y == 0 && bottomPosition == null)
        {
            bottomPosition.y = -5.5f;
        }
        if ( speed == 0 )
        {
            speed = 2;
        }
		 do {

			Vector3 direction = target.y == topPosition.y ? Vector3.up : Vector3.down;
			transform.localPosition += direction * Time.deltaTime * speed;

			yield return null;
		} while (Mathf.Abs((target - transform.localPosition).y) > 0.20f);

            yield return new WaitForSeconds (0.5f);

		Vector3 newTarget = target.y == topPosition.y ? bottomPosition : topPosition;

		StartCoroutine (Move (newTarget));
	}
}
