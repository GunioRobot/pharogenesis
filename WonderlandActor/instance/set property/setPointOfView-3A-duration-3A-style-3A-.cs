setPointOfView: aVector duration: aDuration style: aStyle
	"Sets the object's position and orientation"

	| positionVector rotationVector |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyPointOfView: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what point of view to assign ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine the duration to use for changing the point of view for ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use for changing the point of view for ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so built the animation"
	(aVector isKindOf: WonderlandActor)
		ifTrue: [
					positionVector _ aVector.
					rotationVector _ aVector.
				]
		ifFalse: [
					positionVector _ Array new: 3.
					positionVector at: 1 put: (aVector at: 1).
					positionVector at: 2 put: (aVector at: 2).
					positionVector at: 3 put: (aVector at: 3).

					rotationVector _ Array new: 3.
					rotationVector at: 1 put: (aVector at: 4).
					rotationVector at: 2 put: (aVector at: 5).
					rotationVector at: 3 put: (aVector at: 6).
				].

	^ myWonderland doTogether: { self moveTo: positionVector duration: aDuration style: aStyle.
								self turnTo: rotationVector duration: aDuration style: aStyle }.
