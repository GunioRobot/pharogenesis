prepareToTrackCenterOfRotation: evt with: rotationHandle
	evt hand obtainHalo: self.
	self removeAllHandlesBut: rotationHandle.
	evt hand showTemporaryCursor: Cursor blank