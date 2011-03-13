errorListSelectionIndex: anInteger

	(anInteger ~= 0)
		ifTrue: [(self result errors at: anInteger) debug].