getDragAndDropState
	self dragNDropEnabled
		ifTrue:[^'close to drag and drop']
		ifFalse:[^'open to drag and drop']