distanceTo: aVector
	"Returns the distance from the object to the specified point in the parent's coordinate system"

	| pos |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTarget: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak can only calculate the distance from ' , myName , ' to an actor or 3D point.'.
			^ nil ].

	(aVector isKindOf: WonderlandActor)
		ifTrue: [ pos _ aVector getPosition: self.
				 ^ ((pos at: 1) squared + (pos at: 2) squared + (pos at: 3) squared) sqrt ]
		ifFalse: [ pos _ self getPositionVector.
				  ((aVector at: 1) = asIs) ifTrue: [ aVector at: 1 put: (pos x) ].
				  ((aVector at: 2) = asIs) ifTrue: [ aVector at: 2 put: (pos y) ].
				  ((aVector at: 3) = asIs) ifTrue: [ aVector at: 3 put: (pos z) ].
				  ^ ((self getPositionVector) - aVector) length ].
