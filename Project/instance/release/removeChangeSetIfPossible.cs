removeChangeSetIfPossible

	| itsName |

	changeSet ifNil: [^self].
	changeSet isEmpty ifFalse: [^self].
	(changeSet projectsBelongedTo copyWithout: self) isEmpty ifFalse: [^self].
	itsName _ changeSet name.
	ChangeSorter removeChangeSet: changeSet.
	"Transcript cr; show: 'project change set ', itsName, ' deleted.'"
