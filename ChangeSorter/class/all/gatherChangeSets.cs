gatherChangeSets
	"Collect any change sets created in other projects"

	ChangeSet allInstancesDo: [:each |
		(AllChangeSets includes: each) ifFalse:
			[AllChangeSets add: each]].
	^ AllChangeSets _ AllChangeSets select:
		[:each | each isMoribund not]

	"ChangeSorter gatherChangeSets"