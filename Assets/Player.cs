using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{
    public class Skills 
    {
    	public int[] skills = new int[10];

    	public Skills(int s0, int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9)
    	{
    		skills[0] = s0;
            skills[1] = s1;
            skills[2] = s2;
            skills[3] = s3;
            skills[4] = s4;
            skills[5] = s5;
            skills[6] = s6;
            skills[7] = s7;
            skills[8] = s8;
            skills[9] = s9;
    	}

    	public int getSkill(int skillNum) 
    	{
    		return skills[skillNum];
    	}

    	public void editSkill(int skillNum, int change) 
    	{
    		skills[skillNum] += change;
    	}

    }

    public class Location
    {

    }

    public class Tickets 
    {
    	public int[] tickets = new int[4];

    	public Tickets() 
    	{
    		tickets[0] = 0; //road
    		tickets[1] = 0; //boat
    		tickets[2] = 0; //train
    		tickets[3] = 0; //plane
    	}

    	public void addTicket(int ticketNum, int change)
    	{
    		tickets[ticketNum] += change;
    	}

    	public int getTickets(int ticketNum) 
    	{
    		return tickets[ticketNum];
    	}
    }
}
