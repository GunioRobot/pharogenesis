readonlyWithAll: aCollection notIn: notCollection
	"For performance reasons, this method may return an array rather than a FixedIdentitySet. 
	Therefore it should only be used if the return value does not need to be modified.
	Use #withAll:notIn: if the return value might need to be modified."

	| size |
	aCollection isEmpty ifTrue: [^ #()].
	size := aCollection size = 1 
		ifTrue: [1]
		ifFalse: [self sizeFor: aCollection].
	^ (self new: size) addAll: aCollection notIn: notCollection; yourself