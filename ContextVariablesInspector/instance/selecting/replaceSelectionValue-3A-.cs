replaceSelectionValue: anObject 
	"Refer to the comment in Inspector|replaceSelectionValue:."

	selectionIndex = 1
		ifTrue: [^object]
		ifFalse: [^object tempAt: selectionIndex - 2 put: anObject]