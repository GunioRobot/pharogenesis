uniqueNameFrom: aString
	"If aName is unique to this wonderland's namespace, returns that name. Otherwise creates a unique variant and returns that."

	| index aName |
	aName _ self fixNameFrom: aString.
	(myNamespace includesKey: aName)
			ifFalse: [ ^ aName ].
	aName endsWithDigit ifTrue:[
		index _ aName findLast:[:ch| ch isDigit].
		aName _ (aName copyFrom: 1 to: index-1).
	].
	index _ 1.
	[ myNamespace includesKey: (aName , (index asString)) ]
		whileTrue: [ index _ index + 1 ].
	^ aName , (index asString).
