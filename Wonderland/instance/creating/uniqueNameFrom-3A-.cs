uniqueNameFrom: aString
	"If aName is unique to this wonderland's namespace, returns that name. Otherwise creates a unique variant and returns that."

	| index aName |
	aName _ self fixNameFrom: aString.
	(myNamespace includesKey: aName)
			ifFalse: [ ^ aName ]
			ifTrue: [
						index _ 2.
						[ myNamespace includesKey: (aName , (index asString)) ]
							whileTrue: [ index _ index + 1 ].
						^ aName , (index asString).
					].
