correctSelectionWithString: aString
	| result newPosition |

	"I can't tell if this is a hack or if it's the right thing to do."
	self setSelection: selectionInterval. 

	result _ self correctFrom: selectionInterval first to: selectionInterval last with: aString.
	newPosition _ selectionInterval first + aString size.
	self setSelection: (newPosition to: newPosition - 1).
	^ result