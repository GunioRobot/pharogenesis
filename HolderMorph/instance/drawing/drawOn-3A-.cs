drawOn: aCanvas
	"Draw a border around the item pointed to by the pointer."

	super drawOn: aCanvas.
	submorphs size > 0 ifTrue: [
		aCanvas
			frameRectangle: self selectedRect
			width: 2
			color: Color black].
