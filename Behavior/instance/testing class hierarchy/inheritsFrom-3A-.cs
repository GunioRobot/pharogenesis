inheritsFrom: aClass 
	"Answer whether the argument, aClass, is on the receiver's superclass 
	chain."

	| aSuperclass |
	aSuperclass _ superclass.
	[aSuperclass == nil]
		whileFalse: 
			[aSuperclass == aClass ifTrue: [^true].
			aSuperclass _ aSuperclass superclass].
	^false