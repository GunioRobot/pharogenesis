drawOn: aCanvas 
	"Include a thin red inset border for unaccepted edits"

	super drawOn: aCanvas.
	self hasUnacceptedEdits ifTrue:
		[aCanvas frameRectangle: self innerBounds width: 1 color: Color red]