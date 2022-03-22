using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager:Singleton<AchievementManager>
{

	public achievementSO achievements;

	private Coroutine popupCoroutine;

	private bool coroutineRunning = false;

	private GameObject achievementPopup;

	public void Start()
	{
		achievementPopup = GameObject.Find("AchievementPopup");


	}


	public void AchievementAttained()
	{
		if (GameManager.Instance.asteroidsHit == 1 && achievements.achievements[0].isCompleted)
		{
			Achievement achievement = achievements.achievements[0];
			popupCoroutine = StartCoroutine(ShowPopUp(achievement,2f));
		}
		
		
		
	}



	IEnumerator ShowPopUp(Achievement currentAchievement,float duration)
	{
		while (coroutineRunning)
		{
			yield return null;
		}
		coroutineRunning = true;
		Debug.Log("popup showing"+currentAchievement.achievementName);
		achievementPopup.GetComponent<Animator>().SetTrigger("animate");
		yield return new WaitForSecondsRealtime(duration);
		achievementPopup.GetComponentInChildren<Text>().enabled = false;
		coroutineRunning = false;
	}

}
	
	



