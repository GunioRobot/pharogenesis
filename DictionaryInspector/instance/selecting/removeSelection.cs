removeSelection
	object removeKey: (keyArray at: selectionIndex).
	selectionIndex _ 0.
	contents _ ''.
	self calculateKeyArray.
	self changed: #inspectObject.
	self changed: #selection.