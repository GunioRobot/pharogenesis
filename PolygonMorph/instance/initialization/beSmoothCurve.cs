beSmoothCurve

	smoothCurve == true ifFalse:
		[smoothCurve _ true.
		self computeBounds]