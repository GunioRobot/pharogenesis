selection 
	"Refer to the comment in Inspector|selection."
	selectionIndex = 0 ifTrue:[^''].
	selectionIndex = 1 ifTrue: [^object].
	selectionIndex = 2
		ifTrue: [^object tempsAndValues]
		ifFalse: [^object tempAt: selectionIndex - 2]