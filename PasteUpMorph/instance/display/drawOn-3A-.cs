drawOn: aCanvas
	"Update and draw the turtleTrails form. See the comment in updateTrailsForm."

	super drawOn: aCanvas.

	self updateTrailsForm.
	turtleTrailsForm ifNotNil: [aCanvas paintImage: turtleTrailsForm at: self position].

	(submorphs size > 0 and: [self indicateCursor]) ifTrue:
		[aCanvas
			frameRectangle: self selectedRect
			width: 2
			color: Color black].

