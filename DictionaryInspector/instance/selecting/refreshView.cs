refreshView
	| i |
	i _ selectionIndex.
	self calculateKeyArray.
	selectionIndex _ i.
	self changed: #fieldList.
	self changed: #contents.