hasLiteralSuchThat: aBlock
	"Answer true if litBlock returns true for any literal in this array, even if embedded in further array structure.
	 This method is only intended for private use by CompiledMethod hasLiteralSuchThat:"
	properties ifNil:[^false].
	properties keysAndValuesDo: [:key :value |
		((aBlock value: key)
		 or: [(aBlock value: value)
		 or: [value isArray
			and: [value hasLiteralSuchThat: aBlock]]]) ifTrue: [^true]].
	^false