using UnityEngine;
using System.Collections;
using System;

public class GetInput : MonoBehaviour {

	public enum Direction {
		topleft,
		topright,
		bottomright,
		bottomleft
	}

	public Vector3 BeginPos {
		get {
			return beginPos;
		}
	}
	public Vector3 EndPos {
		get {
			return endPos;
		}
	}
	public Vector3 BeginPosConverted {
		get {
			return new Vector3(beginPos.x, Math.Abs(Screen.height - beginPos.y));
		}
	}
	public Vector3 EndPosConverted {
		get {
			return new Vector3(endPos.x, Math.Abs(Screen.height - endPos.y));
		}
	}
	public DateTime BeginTime {
		get {
			return beginTime;
		}
	}
	public DateTime EndTime {
		get {
			return endTime;
		}
	}
	public bool Touching {
		get {
			return touching;
		}
	}
	public Direction Quadrant {
		get {
			if (BeginPosConverted.y-EndPosConverted.y>0)
			{
				if (BeginPosConverted.x-EndPosConverted.x>0)
				{
					return Direction.topleft;
				}
				return Direction.topright;
			}
			if (BeginPosConverted.x-EndPosConverted.x>0)
			{
				return Direction.bottomleft;
			}
			return Direction.bottomright;
		}
	}
	public TimeSpan Duration {
		get {
			return EndTime - BeginTime;
		}
	}

	Vector3 beginPos;
	Vector3 endPos;
	DateTime beginTime;
	DateTime endTime;
	bool touching;

	public static bool Pressed() {
		return Input.anyKey || Input.touchCount > 0;
	}

	void Update() {
		if (Input.anyKey || Input.touchCount > 0) {
			touching = true;
			endTime = DateTime.Now;
			if (Input.touchCount > 0) {
				var touch = Input.touches[0];
				if (touch.phase == TouchPhase.Began) {
					
					beginPos = touch.position;
					beginTime = DateTime.Now;
				}
				endPos = touch.position;
			} else {
				if (Input.anyKeyDown) {
					beginTime = DateTime.Now;
				}
			}

		} else {
			touching = false;
		}
	}
}
