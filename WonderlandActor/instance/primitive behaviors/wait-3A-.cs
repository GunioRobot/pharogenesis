wait: time
	"Creates an animation where the object merely waits for the specified amount of time"

	| anim |

	[ WonderlandVerifier VerifyDuration: time ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser:
				'Squeak could not determine how long ' , myName , ' should wait because ', msg.
			^ nil ].

	anim _ RelativeAnimation new.

	anim object: self
			update: [:temp | temp ]
			getStartState: [ Interpolateable value: 0 ]
			getEndState: [ time ]
			getReverseState: [ time ]
			style: [:elapsed :total | WonderlandStyle abruptlyAfter: elapsed outOf: total]
			duration: time
			undoable: true
			inWonderland: myWonderland.

	^ anim.