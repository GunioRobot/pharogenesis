selectedClassOrMetaClass
	| c |
	^ (c _ self currentChange) ifNotNil: [c methodClass]