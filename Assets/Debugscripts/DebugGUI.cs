using UnityEngine;
using System.Collections;

public class DebugGUI : MonoBehaviour {

	public GetInput input;

	void OnGUI () {
		GUI.skin.label.fontSize = GUI.skin.box.fontSize = GUI.skin.button.fontSize = 30;
		GUI.Box (new Rect (10,10,600,60), "Touching: " + input.Touching);
		GUI.Box (new Rect (10,80,600,60), "BeginPos: " + input.BeginPos);
		GUI.Box (new Rect (620,80,600,60), "EndPos: " + input.EndPos);
		GUI.Box (new Rect (10,160,600,60), "BeginTime: " + input.BeginTime);
		GUI.Box (new Rect (620,160,600,60), "EndTime: " + input.EndTime);
		GUI.Box (new Rect (10,240,1210,60), "Duration: " + input.Duration);
		GUI.Box (new Rect (10,320,1210,60), "Quadrant: " + input.Quadrant);
		GUI.Box (new Rect (10,400,600,60), "BeginConv: " + input.BeginPosConverted);
		GUI.Box (new Rect (620,400,600,60), "EndConv: " + input.EndPosConverted);
	}
}
