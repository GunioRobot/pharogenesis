mouseDown: anEvent
	| xPosition newTab |
	xPosition _ anEvent cursorPoint x.
	newTab _
		((self tabs detect: [ :anAssociation | | tabBounds |
				tabBounds _ anAssociation key bounds.
				(tabBounds left <= xPosition) and: [ tabBounds right >= xPosition]]
			ifNone: [nil])
		key).
	newTab ifNil: [^ self].
	newTab = activeTab ifFalse: [ self activeTab: newTab ]
