removeSelection
	(selectionIndex <= object class instSize) ifTrue: [^ self changed: #flash].
	object remove: self selection.
	selectionIndex _ 0.
	contents _ ''.
	self changed: #inspectObject.
	self changed: #fieldList.
	self changed: #selection.
	self changed: #selectionIndex.