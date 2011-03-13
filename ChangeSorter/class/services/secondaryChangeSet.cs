secondaryChangeSet
	"Answer a likely change set to use as the second initial one in a Dual Change Sorter.  "
	| last |
	self gatherChangeSets.
	AllChangeSets size == 1 ifTrue: [^ AllChangeSets first].
	^ (last _ AllChangeSets last) == Smalltalk changes
		ifTrue: 	[AllChangeSets at: (AllChangeSets size - 1)]
		ifFalse:	[last]