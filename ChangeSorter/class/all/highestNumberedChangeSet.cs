highestNumberedChangeSet
	"ChangeSorter highestNumberedChangeSet"
	^ (self allChangeSetNames select: [:aString | aString startsWithDigit] thenCollect:
		[:aString | aString initialInteger]) max
