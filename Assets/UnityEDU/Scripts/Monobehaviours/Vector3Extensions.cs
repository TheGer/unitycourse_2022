using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extensions {

	// Use this for initialization

	public static Vector3 randomPositionOnScreen(this Vector3 pos,Camera currentCamera,Vector3? margin = new Vector3?())
	{
		Vector3 randomPosition;
		float cameraSizeY = currentCamera.orthographicSize;
		float cameraSizeX = cameraSizeY * currentCamera.aspect;
		

		randomPosition = new Vector3(
			Random.Range(-cameraSizeY, cameraSizeY),
			Random.Range(-cameraSizeX, cameraSizeX),
			0f);
		return keepOnScreen(randomPosition,currentCamera,margin);
	}

	
	public static Vector3 keepOnScreen(this Vector3 pos, Camera currentCamera,Vector3? margin = new Vector3?())
	{
		if (margin != null)
		{
		
			float cameraSize = currentCamera.orthographicSize;

			float limity = cameraSize - margin.Value.y;
			float limitx = cameraSize * currentCamera.aspect - margin.Value.x;
				
			pos.y = Mathf.Clamp(pos.y,
				-limity,
				limity);
			
			pos.x = Mathf.Clamp(pos.y,
				-limitx,
				limitx);
			
		
		}
		
		
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
	

		/*----------- TO DISCUSS ----------- 
		Alternative Approaches
		public static Vector3 CalculateScreenBounds(Camera cam){
			float boundsX = cam.aspect * cam.orthographicSize;
			float boundsY = cam.orthographicSize;
			return new Vector3(boundsX, boundsY, 1); //Multiply x and y by 2 to get screen size
		}
		public static Vector3 ScreenWrap(this Vector3 pos, Camera cam)
		{
			Vector3 viewportPos = cam.WorldToViewportPoint(pos);
			Vector3 newPos = pos;
			if (viewportPos.x > 1 || viewportPos.x < 0) newPos.x = -newPos.x;
			if (viewportPos.y > 1 || viewportPos.y < 0) newPos.y = -newPos.y;
			return newPos;
		}
		*/
}
