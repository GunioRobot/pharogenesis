failureListSelectionIndex: anInteger

	(anInteger ~= 0)
		ifTrue: [(self result failures at: anInteger) debug].