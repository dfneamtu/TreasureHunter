using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=UnityEngine.Random;

public static class ML_Algo : object
{
   public static int ML ()
   {
   	  double basePercentage = .55;
      int minValue = 0;
      int maxValue = 4;
      int returnValue;
      double remainingPercentage = 1.0 - basePercentage;


       int summation = 0;

       for (int i = (maxValue - minValue); i > 0; i--)
       {
           summation += i;
       }


       double randomNum = Random.Range(0, 1000) / 1000.0;
       //double randomNum = rand.Next(1000) / 1000.0;
       //Console.WriteLine("RANDOM NUM: " + randomNum);

       double multiplier = remainingPercentage / summation;

       double lowerBound = 0;
       double upperBound = basePercentage;
       int multiplierConstant = maxValue - minValue;

       for (int i = minValue; i <= maxValue; i++)
       {

       	//Console.WriteLine("Lower Bound: " + lowerBound);
       	//Console.WriteLine("Upper HBound: " + upperBound);

       	if (lowerBound <= randomNum && randomNum < upperBound)
       	{
           	returnValue = i;
           	//Console.WriteLine("RETURNING: " + returnValue);
           	return returnValue;
           	}
       	else
       	{
           	lowerBound = upperBound;
           	upperBound = upperBound + (multiplier * multiplierConstant);
           	multiplierConstant--;
       	}
       }
    return maxValue;
   }
} 