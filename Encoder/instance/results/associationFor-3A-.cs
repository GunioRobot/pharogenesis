associationFor: aClass

	| name |
	name _ Smalltalk keyAtIdentityValue: aClass ifAbsent: [^Association new value: aClass].
	^Smalltalk associationAt: name