versionString
	"Answer a short string describing this version of Celeste."

	| highestChangeSet versionAddendum |

	"the changeset number should probably be removed whenever Celeste settles down"
	highestChangeSet _ ChangeSorter highestNumberedChangeSet.
	versionAddendum _ highestChangeSet
		ifNil: ['.x']
		ifNotNil: ['.' , highestChangeSet name initialIntegerOrNil printString].
	^ 'Celeste 2.0' , versionAddendum