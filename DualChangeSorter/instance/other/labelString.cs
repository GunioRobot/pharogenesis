labelString
	"The window label"

	| leftName rightName changesName |
	leftName := leftCngSorter changeSetCategory categoryName.
	rightName := rightCngSorter changeSetCategory categoryName.
	changesName := 'Changes go to "', ChangeSet current name,  '"'.
	^ ((leftName ~~ #All) or: [rightName ~~ #All])
		ifTrue:
			['(', leftName, ') - ', changesName, ' - (', rightName, ')']
		ifFalse:
			[changesName]