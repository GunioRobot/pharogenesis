adjustTargetMouseDownHaloSize: aFractionalPoint

	self targetProperties mouseDownHaloWidth: ((aFractionalPoint x * 10) rounded max: 0).
