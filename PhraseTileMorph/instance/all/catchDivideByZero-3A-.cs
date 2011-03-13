catchDivideByZero: aStream
	"See if I am have divide as my operator.  If so, insert a test in the argument to divide."

	(submorphs at: 2) type = #operator ifFalse: [^ false].		"not me"
	(submorphs at: 2) operatorOrExpression == #/ ifFalse: [^ false].	"not me"
	aStream space.
	aStream nextPutAll: '(self beNotZero: '.
	(submorphs at: 3) storeCodeOn: aStream.
	aStream nextPut: $).
	^ true