setSize: aVector duration: time style: aStyle
	"Sets the object's position and orientation"

	| meshSize |

	"Check our arguments to make sure they're valid"
	[ WonderlandVerifier VerifyTriple: aVector ]
		ifError: [ :msg :rcvr |
			myWonderland reportErrorToUser: 'Squeak could not determine what size to make ' , myName , ' because ', msg.
			^ nil ].

	"Our parameters check out, so build the animation"
	meshSize _ self getBoundingBox extent.

	"Now make sure we don't accidentally divide by zero"
	((meshSize x) = 0) ifTrue: [ aVector at: 1 put: 1.
							    meshSize x: 1 ].

	((meshSize y) = 0) ifTrue: [ aVector at: 2 put: 1.
							    meshSize y: 1 ].

	((meshSize z) = 0) ifTrue: [ aVector at: 3 put: 1.
							    meshSize z: 1 ].

	^ self resizeTopToBottom: (aVector at: 2) / (meshSize y)
			leftToRight: (aVector at: 1) / (meshSize x)
			frontToBack: (aVector at: 3) / (meshSize z)
			duration: time
			style: aStyle.
