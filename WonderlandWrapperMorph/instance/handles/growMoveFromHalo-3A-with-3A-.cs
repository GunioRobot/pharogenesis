growMoveFromHalo: evt with: handle
	| newExtent scale |
	newExtent _ (self pointFromWorld: (evt cursorPoint - self growPositionOffset)) - self topLeft.
	newExtent _ newExtent max: 1@1.
	scale _ newExtent r / bounds extent r.
	evt shiftPressed
		ifTrue:[scale _ B3DVector3 x: scale y: scale z: 1.0]
		ifFalse:[scale _ B3DVector3 x: scale y: scale z: scale].
 	myActor resizeRightNow: scale undoable: false.
	handle position: evt cursorPoint - (handle extent // 2).