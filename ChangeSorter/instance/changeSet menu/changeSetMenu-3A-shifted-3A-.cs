changeSetMenu: aMenu shifted: isShifted 
	"Could be for a single or double changeSorter"
	aMenu title: 'Change Set:
' , myChangeSet name.
	isShifted ifTrue: [^ self shiftedChangeSetMenu: aMenu].
	aMenu add: 'make changes go to me' action: #newCurrent.
	aMenu addLine.
	aMenu add: 'new change set...' action: #newSet.
	aMenu add: 'find...' action: #findCngSet.
	aMenu add: 'show...' action: #chooseCngSet.
	aMenu add: 'rename change set' action: #rename.
	aMenu addLine.
	aMenu add: 'file out' action: #fileOut.
	aMenu add: 'mail to list' action: #mailOut.
	aMenu add: 'browse methods' action: #browseChangeSet.
	aMenu addLine.
	parent
		ifNotNil: 
			[aMenu add: 'copy all to other side' action: #copyAllToOther.
			aMenu add: 'submerge into other side' action: #submergeIntoOtherSide.
			aMenu add: 'subtract other side' action: #subtractOtherSide.
			aMenu addLine].
	myChangeSet hasPreamble
		ifTrue: 
			[aMenu add: 'edit preamble' action: #addPreamble.
			aMenu add: 'remove preamble' action: #removePreamble]
		ifFalse: [aMenu add: 'add preamble' action: #addPreamble].
	"aMenu add: 'edit preamble...' action: #editPreamble."
	myChangeSet hasPostscript
		ifTrue: 
			[aMenu add: 'edit postscript...' action: #editPostscript.
			aMenu add: 'remove postscript' action: #removePostscript]
		ifFalse: [aMenu add: 'add postscript...' action: #editPostscript].
	aMenu addLine.
	aMenu add: 'destroy change set' action: #remove.
	aMenu addLine.
	aMenu add: 'more...' action: #shiftedYellowButtonActivity.
	^ aMenu