doneWithEdits
	"If in a SyntaxMorph, shrink min width after editing"

	super doneWithEdits.
	(owner respondsTo: #parseNode) ifTrue: [minimumWidth _ 8].