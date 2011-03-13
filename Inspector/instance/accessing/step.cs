step
	"Continuously update the value of the selected item"
	| newText |
	newText _ (selectionIndex = 2) | (selectionIndex = 0)
		ifTrue: [self selection]
		ifFalse: [self selection printString].
	newText = contents ifFalse:
		[contents _ newText.
		self changed: #contents]