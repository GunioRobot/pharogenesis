labelString
	"The window label"

	| leftName rightName changesName |
	leftName _ leftCngSorter changeSetCategory categoryName.
	rightName _ rightCngSorter changeSetCategory categoryName.
	changesName _ 'Changes go to "', ChangeSet current name,  '"'.
	^ ((leftName ~~ #All) or: [rightName ~~ #All])
		ifTrue:
			['(', leftName, ') - ', changesName, ' - (', rightName, ')']
		ifFalse:
			[changesName]