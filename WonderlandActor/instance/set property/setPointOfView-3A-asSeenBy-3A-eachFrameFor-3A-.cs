setPointOfView: aVector asSeenBy: reference eachFrameFor: aLifetime
	"Sets the object's position and orientation"

	| positionVector rotationVector |

	[ WonderlandVerifier VerifyPointOfView: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what point of view to assign ' , myName , ' because ', msg.
			^ nil ].

	( aVector isKindOf: WonderlandActor) ifTrue: [
			myWonderland reportErrorToUser: 'Squeak does not allow you to use an Actor to specify the point of view when using asSeenBy.'.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can not set the point of view for ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyNonNegativeNumber: aLifetime ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine how long ' , myName , ' should keep this point of view because ', msg.
			^ nil ].

	positionVector _ Array new: 3.
	positionVector at: 1 put: (aVector at: 1).
	positionVector at: 2 put: (aVector at: 2).
	positionVector at: 3 put: (aVector at: 3).

	rotationVector _ Array new: 3.
	rotationVector at: 1 put: (aVector at: 4).
	rotationVector at: 2 put: (aVector at: 5).
	rotationVector at: 3 put: (aVector at: 6).

	myWonderland getUndoStack push: (UndoPOVChange for: self
														from: (self getPointOfView)).

	^ self doEachFrame: [ 
							self moveToRightNow: positionVector undoable: false.
							self turnToRightNow: rotationVector undoable: false.
						]
			for: aLifetime.

