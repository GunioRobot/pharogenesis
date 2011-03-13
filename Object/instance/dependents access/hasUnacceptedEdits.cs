hasUnacceptedEdits
	"Answer true if any of the views on this object has unaccepted edits."

	self dependents do: [:v |
		v == self ifFalse: [
			v hasUnacceptedEdits ifTrue: [^ true]]].
	^ false 
