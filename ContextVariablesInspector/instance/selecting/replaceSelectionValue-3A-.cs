replaceSelectionValue: anObject 
	"Refer to the comment in Inspector|replaceSelectionValue:."

	selectionIndex = 1
		ifTrue: [^object]
		ifFalse: [^object tempAt: selectionIndex - 1 put: anObject]