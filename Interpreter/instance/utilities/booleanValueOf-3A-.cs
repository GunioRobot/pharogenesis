booleanValueOf: obj

	obj = trueObj ifTrue: [ ^ true ].
	obj = falseObj ifTrue: [ ^ false ].
	successFlag _ false.
	^ nil