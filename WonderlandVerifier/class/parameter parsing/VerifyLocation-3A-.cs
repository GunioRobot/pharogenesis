VerifyLocation: parameter
	"If the parameter is a valid location this method returns true, otherwise it throws an exception"

	((((((((((parameter = toLeftOf) or: [ parameter = toRightOf ]) or: [ parameter = onTopOf ])
			or: [ parameter = onBottomOf ]) or: [ parameter = inFrontOf ])
			or: [ parameter = inBackOf ]) or: [ parameter = behind ])
			or: [ parameter = below ]) or: [ parameter = onFloorOf ])
			or: [ parameter = onCeilingOf ])
					ifTrue: [ ^ true ]
					ifFalse: [ self error: (parameter asString) , ' is not a valid location. ' ].
