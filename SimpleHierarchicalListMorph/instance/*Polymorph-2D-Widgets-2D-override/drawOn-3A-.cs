drawOn: aCanvas
	"Draw the selection and lines."
	
	super drawOn: aCanvas.
	selectedMorph ifNotNil:
		[aCanvas clipBy: self innerBounds during: [:c |
			c
				fillRectangle: self selectionFrame
				color: (self selectionColorToUse ifNil: [Preferences textHighlightColor])]].
	self drawLinesOn: aCanvas