at: anObject put: anotherObject
	properties isNil ifTrue: [properties _ IdentityDictionary new].
	^ properties at: anObject put: anotherObject