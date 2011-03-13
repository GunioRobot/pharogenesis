at: anObject put: anotherObject
	properties isNil ifTrue: [properties := IdentityDictionary new].
	^ properties at: anObject put: anotherObject