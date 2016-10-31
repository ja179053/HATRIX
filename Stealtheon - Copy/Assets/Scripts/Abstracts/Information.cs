using UnityEngine;
//Information stores static information used in the game.
[AuthorAttribute ("JJ", TeamRole.Programmer)]
public abstract class Information
{
	//Conveyor data
	public static int conveyorDirection = -1;
	public static float conveyorSpeed = 0.03f;
	//Minimum input to work
	public static float minimumInput = 0.08f;
	//Functions
	public static int Enough(float f, float comparable){
		if (f > comparable || f < -comparable) {
			return 1;
		} else {
			return 0;
		}
	}
	public static int RoundAway(float f){
		int i = (int)f;
		if (i > f) {
			return i + 1;
		} else if (i < f) {
			return i - 1;
		} else {
			return i;
		}
	}
}
