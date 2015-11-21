using UnityEngine;
using System.Collections;

public class Brick {
	private Vector3[] points;

	public Brick () {
		points = new Vector3[] {new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0)};
	}

	public Brick (Vector3 init) {
		points = new Vector3[] {
			new Vector3(init.x, init.y, init.z),
			new Vector3(init.x, init.y, init.z),
			new Vector3(init.x, init.y, init.z),
			new Vector3(init.x, init.y, init.z)
		};
	}

	public Brick (Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4) {
		points = new Vector3[] {
			new Vector3(v1.x, v1.y, v1.z),
			new Vector3(v2.x, v2.y, v2.z),
			new Vector3(v3.x, v3.y, v3.z),
			new Vector3(v4.x, v4.y, v4.z)
		};
	}

	// 0 <= index <= 3
	Vector3 GetPoint (int index) {
		return points[index];
	}

	// 0 <= index <= 3
	void SetPoint (int index, Vector3 v) {
		points[index] = new Vector3(v.x, v.y, v.z);
	}
}
