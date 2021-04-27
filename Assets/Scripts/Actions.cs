using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Actions : object
{
	public static int actionsRemaining = 3;

	public static int getActions() 
	{
		return actionsRemaining;
		Debug.Log(actionsRemaining.ToString());
	}

	public static void reduceActions() 
	{
		actionsRemaining--;
		Debug.Log(actionsRemaining.ToString());

		if (actionsRemaining == 0)
		{
			actionsRemaining = 3; //for now, just refresh actions
		}
	}
	
	
}
