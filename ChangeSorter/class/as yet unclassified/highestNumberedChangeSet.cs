highestNumberedChangeSet
	"ChangeSorter highestNumberedChangeSet"
	| aList |
	aList _ (self allChangeSetNames select: [:aString | aString startsWithDigit] thenCollect:
		[:aString | aString initialIntegerOrNil]).
	^ (aList size > 0)
		ifTrue:
			[aList max]
		ifFalse:
			[nil]
