stringAsObject: aString
	"Answer the given string in object form."

	^self needsConversion
		ifTrue: [self objectClass readFromString: aString]
		ifFalse: [aString]