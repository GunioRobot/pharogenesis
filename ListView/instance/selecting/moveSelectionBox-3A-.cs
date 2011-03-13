moveSelectionBox: anInteger 
	"Presumably the selection has changed to be anInteger. Deselect the 
	previous selection and display the new one, highlighted."

	selection ~= anInteger
		ifTrue: 
			[self deselect.
			selection := anInteger.
			self displaySelectionBox].
	self isSelectionBoxClipped
		ifTrue: [self scrollSelectionIntoView]