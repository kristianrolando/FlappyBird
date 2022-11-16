using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
	public delegate void CountdownFinished();
	public static event CountdownFinished OnCountdownFinished;

	[SerializeField] TextMeshProUGUI countText;
	[SerializeField] int startCount = 3;

	void Start()
	{
		countText.text = startCount.ToString();
		StartCoroutine("Countdown");
	}

	IEnumerator Countdown()
	{
		int count = startCount;
		for (int i = 0; i < startCount; i++)
		{
			countText.text = count.ToString();
			yield return new WaitForSeconds(1);
			count -= 1;

		}
		if (count <= 0)
			OnCountdownFinished?.Invoke();
	}
}
