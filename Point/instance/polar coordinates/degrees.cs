degrees
	"Answer the angle the receiver makes with origin in degrees. right is 0; down is 90."
	| tan theta |
	x = 0
		ifTrue: [y >= 0
				ifTrue: [^ 90.0]
				ifFalse: [^ 270.0]]
		ifFalse: 
			[tan _ y asFloat / x asFloat.
			theta _ tan arcTan.
			x >= 0
				ifTrue: [y >= 0
						ifTrue: [^ theta radiansToDegrees]
						ifFalse: [^ 360.0 + theta radiansToDegrees]]
				ifFalse: [^ 180.0 + theta radiansToDegrees]]