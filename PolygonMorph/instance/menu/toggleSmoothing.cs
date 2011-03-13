toggleSmoothing

	smoothCurve _ smoothCurve not.
	handles ifNotNil: [self removeHandles; addHandles].
	self computeBounds