emphasized: code

	code = 0 ifTrue: [^ self].
	derivatives isNil ifTrue: [^ self].
	^ (derivatives at: code) ifNil: [self].
