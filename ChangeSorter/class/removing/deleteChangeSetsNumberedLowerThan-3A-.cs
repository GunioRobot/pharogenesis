deleteChangeSetsNumberedLowerThan: anInteger
	"Delete all changes sets whose names start with integers smaller than anInteger"

	ChangeSorter removeChangeSetsNamedSuchThat:
		[:aName | aName first isDigit and: [aName initialIntegerOrNil < anInteger]].

	"ChangeSorter deleteChangeSetsNumberedLowerThan: (ChangeSorter highestNumberedChangeSet name initialIntegerOrNil - 500)"
