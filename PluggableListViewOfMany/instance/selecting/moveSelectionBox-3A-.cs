moveSelectionBox: anInteger 
	"Presumably the selection has changed to be anInteger. Deselect the 
	previous selection and display the new one, highlighted."
	selection ~= anInteger
		ifTrue: 
			[selection _ anInteger.
			self displaySelectionBox]