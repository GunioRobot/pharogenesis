selection 
	"Refer to the comment in Inspector|selection."
	selectionIndex = 0 ifTrue:[^object printString].
	selectionIndex = 1 ifTrue: [^object].
	selectionIndex = 2 ifTrue:[^object longPrintString].
	selectionIndex > 2
		ifTrue: [^object perform: (self fieldList at: selectionIndex)]