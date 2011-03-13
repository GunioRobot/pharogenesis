selectionIsConflict
	"Answer whether the currently selected change is a conflict."

	^self selectedChangeWrapper isNil
		ifTrue: [false]
		ifFalse: [self selectedChangeWrapper isConflict]