VerifyDirection: parameter
	"If the parameter is a valid direction this method returns true, otherwise it throws an exception"

	(((((((((parameter = left) or: [ parameter = right ]) or: [ parameter = up ])
			or: [ parameter = down ]) or: [ parameter = forward ])
			or: [ parameter = back ]) or: [ parameter = backward ])
			or: [ parameter = ccw ]) or: [ parameter = cw ])
					ifTrue: [ ^ true ]
					ifFalse: [ self error: (parameter asString) , ' is not a valid direction. ' ].
