allChangeSetNamesAfter: aString
	| names index |
	names _ self allChangeSetNames.
	index _ names indexOf: aString ifAbsent: [self error: 'not found'].
	^ names copyFrom: index to: names size

	"ChangeSorter allChangeSetNamesAfter: 'GenericTfr'"