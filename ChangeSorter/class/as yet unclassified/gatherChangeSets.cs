gatherChangeSets
	"Collect any change sets created in other projects  1/22/96 sw
	 2/7/96 sw: filter out moribund guys"

	ChangeSet allInstancesDo: [:each |
		(AllChangeSets includes: each) ifFalse:
			[AllChangeSets add: each]].
	^ AllChangeSets _ AllChangeSets select:
		[:each | each isMoribund not]

	"ChangeSorter gatherChangeSets"