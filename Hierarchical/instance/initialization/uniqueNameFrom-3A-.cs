uniqueNameFrom: aString
	"Return a unique name for the string in the context of the receiver's name space"
	| index aName myNamespace |
	aName _ aString.
	myNamespace _ self getChildren asSet collect:[:each| each getName].
	(myNamespace includes: aName)
			ifFalse: [ ^ aName ].
	aName endsWithDigit ifTrue:[
		index _ aName findLast:[:ch| ch isDigit].
		aName _ (aName copyFrom: 1 to: index-1).
	].
	index _ 1.
	[ myNamespace includes: (aName , (index asString)) ]
		whileTrue: [ index _ index + 1 ].
	^ aName , (index asString).
