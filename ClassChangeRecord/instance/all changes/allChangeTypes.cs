allChangeTypes

	| chgs |
	(priorName ~~ nil and: [changeTypes includes: #rename]) ifTrue:
		[(chgs _ changeTypes copy) add: 'oldName: ' , priorName.
		^ chgs].
	^ changeTypes