turnTo: aVector duration: aDuration asSeenBy: reference style: aStyle
	"Turns the object to the specified orientation in its parent's coordinate system using the specified style over the specified duration."

	| anim endStateFunc angles newComposite vectorMatrix |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTarget: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine where to turn ' , myName , ' to because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyDuration: aDuration ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the duration to use for turning ' , myName , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyReferenceFrame: reference ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak can not turn ' , myName , ' relative to ' , (reference asString) , ' because ', msg.
			^ nil ].

	[ WonderlandVerifier VerifyStyle: aStyle ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine the style to use to turn ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	anim _ AbsoluteAnimation new.

	vectorMatrix _ B3DMatrix4x4 identity.
	endStateFunc _ [
		vectorMatrix setIdentity.
		angles _ self getAngles: reference.
		((aVector at: 1) = asIs) ifFalse: [ angles at: 1 put: (aVector at: 1) ].
		((aVector at: 2) = asIs) ifFalse: [ angles at: 2 put: (aVector at: 2) ].
		((aVector at: 3) = asIs) ifFalse: [ angles at: 3 put: (aVector at: 3) ].
		vectorMatrix rotation: (B3DVector3 x: (angles at: 1) y: (angles at: 2) z: (angles at: 3)).
		newComposite _ (myParent getMatrixToRoot) composeWith: (reference getMatrixFromRoot).
		newComposite _ newComposite composeWith: vectorMatrix.
		newComposite asQuaternion.
					].

	anim object: self
			update: [:tQuat | self setRotationMatrix: (tQuat asMatrix4x4) ]
			getStartState: [ composite asQuaternion ]
			getEndState: endStateFunc
			style: aStyle
			duration: aDuration
			undoable: true
			inWonderland: myWonderland.

	^ anim.
