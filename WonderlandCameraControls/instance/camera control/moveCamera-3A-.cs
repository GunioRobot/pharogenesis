moveCamera: evt
	"Move the camera an amount and direction determined by the current position of the mouse and which modifier keys are held down."
	| offset dt |
	myMoveScale == nil ifTrue:[myMoveScale _ 0.1].
	myRotationScale == nil ifTrue:[myRotationScale _ 0.01].
	dt _ myScheduler getElapsedTime.
	offset _ (self getCenter) - (0@8) - (evt cursorPoint).

	(evt shiftPressed)
		ifTrue: [ (evt controlKeyPressed)
					ifTrue: [
						myCamera turnRightNow: up numberOfTurns: (dt * (offset y) * myRotationScale)
										undoable: false.
							]
					ifFalse: [
						myCamera moveRightNow: up distance: (dt * (offset y) * myMoveScale)
										undoable: false.
						myCamera moveRightNow: left distance: (dt * (offset x) * myMoveScale)
										undoable: false.
							].
				]
		ifFalse: [ (evt controlKeyPressed)
					ifTrue: [
						myCamera turnRightNow: left numberOfTurns: (dt * (offset x) * myRotationScale)
										undoable: false.
							]
					ifFalse: [
						myCamera moveRightNow: forward distance: (dt * (offset y) * myMoveScale)
										undoable: false.
						myCamera turnRightNow: left numberOfTurns: (dt * (offset x) * myRotationScale)
										undoable: false.
							].
				].
