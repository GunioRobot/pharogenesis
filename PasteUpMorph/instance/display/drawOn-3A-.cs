drawOn: aCanvas
	"Update and draw the turtleTrails form. See the comment in updateTrailsForm."

	super drawOn: aCanvas.
	(self griddingOn and: [self gridVisible]) ifTrue:
		[aCanvas fillRectangle: self bounds fillStyle:
			(self gridFormOrigin: self gridOrigin + self position grid: self gridModulus background: nil line: Color lightGray)].
	self updateTrailsForm.
	turtleTrailsForm ifNotNil: [aCanvas paintImage: turtleTrailsForm at: self position].

	(submorphs size > 0 and: [self indicateCursor]) ifTrue:
		[aCanvas
			frameRectangle: self selectedRect
			width: 2
			color: Color black].

