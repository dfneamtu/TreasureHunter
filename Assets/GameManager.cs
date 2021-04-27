using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager : object
{
	public static int actionsRemaining = 3;

	public static int getActions() 
	{
		return actionsRemaining;
	}

	public static void minusAction()
	{
		actionsRemaining--;
		if (actionsRemaining == 0)  //for now, reset actions to 3 when they run out
		{
			actionsRemaining = 3;
		}
	}


}
