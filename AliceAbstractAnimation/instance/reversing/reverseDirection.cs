reverseDirection
	"Changes the direction an animation runs in (forward or in reverse)"

	(direction = Forward) ifTrue: [ direction _ Reverse ]
						 ifFalse: [ direction _ Forward ].
