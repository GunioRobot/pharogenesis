moveRightNow: aDirection distance: aDistance undoable: isUndoable
	"Move this object in the specified direction instantaneously"

	| a3DVector aMatrix |

	(isUndoable) ifTrue: [
		myWonderland getUndoStack push: (UndoPositionChange for: self from: (self getPosition)).
						].

	[ a3DVector _ self makeVectorFromDistance: aDistance andDirection: aDirection. ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak does not know how to move ' , myName , ' in that direction.'.
			^ nil ].

	aMatrix _ B3DMatrix4x4 identity translation: a3DVector.

	composite _ composite composeWith: aMatrix.


