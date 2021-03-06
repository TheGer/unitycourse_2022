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

	[SerializeField]
	public enum ACTIONS
	{
		CurrentLevel = 0,
		ShotsFired = 1,
		AsteroidsHit = 2,
		Score = 3 ,
		LuckyShot = 4
	}
	
	public void Start()
	{
		achievementPopup = GameObject.Find("AchievementPopup");
		StartCoroutine(PollAchievements());

	}


	public IEnumerator PollAchievements()
	{
		while(true)
		{
			foreach (Achievement a in achievements.achievements)
			{
	
				if (a.Poll() != null)
				{
					StartCoroutine(ShowPopUp(a, 2f));
				}
			}
			yield return null;
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
		currentAchievement.isCompleted = true;
		
		achievementPopup.GetComponent<Animator>().SetTrigger("animate");
		yield return new WaitForSecondsRealtime(duration);
		achievementPopup.GetComponentInChildren<Text>().enabled = false;
		coroutineRunning = false;
	}

}
	
	



