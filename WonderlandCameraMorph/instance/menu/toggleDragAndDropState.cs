toggleDragAndDropState
	self dragNDropEnabled
		ifTrue:[self disableDragNDrop]
		ifFalse:[self enableDragNDrop]