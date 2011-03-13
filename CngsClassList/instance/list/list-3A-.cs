list: anObject
	list _ anObject.
	listIndex _ 0.
	self changed: #list.
	parent changed: #class