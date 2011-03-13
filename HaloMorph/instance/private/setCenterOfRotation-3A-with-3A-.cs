setCenterOfRotation: evt with: rotationHandle
	| localPt |
	evt hand obtainHalo: self.
	evt hand showTemporaryCursor: nil.
	localPt _ innerTarget transformFromWorld globalPointToLocal: rotationHandle center.
	innerTarget setRotationCenterFrom: localPt.
	self endInteraction
