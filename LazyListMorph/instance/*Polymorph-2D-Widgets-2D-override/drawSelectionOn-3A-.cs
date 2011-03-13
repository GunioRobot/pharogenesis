drawSelectionOn: aCanvas
	"Draw the selection background."
	
	| frame |
	selectedRow ifNil: [ ^self ].
	selectedRow = 0 ifTrue: [ ^self ].
	frame := self selectionFrameForRow: selectedRow.
	aCanvas
		fillRectangle: frame
		color: (listSource selectionColorToUse ifNil: [Preferences textHighlightColor])