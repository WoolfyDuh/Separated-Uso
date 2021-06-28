using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class shrinkingcircle : MonoBehaviour
{
	DeactivateBall deactivateBall;
  [SerializeField] private float duration = 3f;
	Vector2 startScale = new Vector2(2f, 2f);
	Vector2 endScale = new Vector2(1f, 1f);
	bool isActive = false;

	private void Awake()
	{
		deactivateBall = gameObject.GetComponentInParent<DeactivateBall>();
		deactivateBall.AddToDisableCallback(Refresh);
	}
	// Update is called once per frame
	void Update()
    {
        
		if (gameObject.activeSelf && !isActive)
		{
			transform.localScale = startScale;
			isActive = true;
			StartCoroutine(Shrink());
		}

    }

	IEnumerator Shrink()
	{
		float time = 0;
		transform.localScale = startScale;
		while(time < duration)
		{
		transform.localScale = Vector2.Lerp(startScale, endScale, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		transform.localScale = endScale;
	}

	public void Refresh()
	{
		transform.localScale = startScale;
		isActive = false;
	}
}
