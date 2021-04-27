using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
   public int[] tickets;
   public int[] skills;
   public string location;

   public Players(int s1, int s2, int s3, int s4, int s5, int s6, int s7, int s8, int s9, int s10) 
   {
   		skills[0] = s1;
   		skills[1] = s2;
   		skills[2] = s3;
   		skills[3] = s4;
   		skills[4] = s5;
   		skills[5] = s6;
   		skills[6] = s7;
   		skills[7] = s8;
   		skills[8] = s9;
   		skills[9] = s10;

   		tickets[0] = 0;
   		tickets[1] = 0;
   		tickets[2] = 0;
   		tickets[3] = 0;
   }

   public int getSkill(int skillNum) 
   {
   		return skills[skillNum];
   }

   public void editSkill(int skillNum, int change) 
   {
   		skills[skillNum] += change;
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
