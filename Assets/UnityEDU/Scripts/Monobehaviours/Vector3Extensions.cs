using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions {

	// Use this for initialization


	
	public static Vector3 keepOnScreen(this Vector3 pos, Camera currentCamera)
	{

		
		Vector3 currentViewportPoint = currentCamera.WorldToViewportPoint(pos);
		if (currentViewportPoint.x > 1)
		{
			pos = new Vector3(
				currentCamera.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).x,
				currentCamera.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).y, 0f);

		}

		if (currentViewportPoint.x < 0)
		{
			pos = new Vector3(
				currentCamera.ViewportToWorldPoint(new Vector3(1, currentViewportPoint.y)).x,
				currentCamera.ViewportToWorldPoint(new Vector3(0, currentViewportPoint.y)).y, 0f);
		}

		if (currentViewportPoint.y > 1)
		{
			pos = new Vector3(
				currentCamera.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).x,
				currentCamera.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).y, 0f);
		}

		if (currentViewportPoint.y < 0)
		{
			pos= new Vector3(
				currentCamera.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 0)).x,
				currentCamera.ViewportToWorldPoint(new Vector3(currentViewportPoint.x, 1)).y, 0f);
		}

		return pos;

	}


	public static float GetXMin(Camera currentCamera)  //statics make an attribute/method class level.. no need of objects
		{
			float XMin = currentCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
			//  Debug.Log("XMin: " + XMin.ToString());
			return XMin;
		}

		public static float GetXMax(Camera currentCamera)
		{
			float XMax = currentCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
			//  Debug.Log("XMax: " + XMax.ToString());
			return XMax;
		}


		public static float GetYMin(Camera currentCamera)
		{
			float YMin = currentCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
			//  Debug.Log("YMin: " + YMin.ToString());
			return YMin;
		}

		public static float GetYMax(Camera currentCamera)
		{
			float YMax = currentCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
			//Debug.Log("YMax: " + YMax.ToString());
			return YMax;
		}
	


}
