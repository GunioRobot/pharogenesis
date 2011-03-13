drawOn: aCanvas
	"Update and draw the turtleTrails form. See the comment in updateTrailsForm."

	super drawOn: aCanvas.
	(lastTurtlePositions ~~ nil and:
	 [lastTurtlePositions size > 0]) ifTrue:
		["Note: trails form is created when first pen goes down"
		self createOrResizeTrailsForm.
		self updateTrailsForm].

	turtleTrailsForm ifNotNil:
		[aCanvas image: turtleTrailsForm at: self position].
	self recordTurtlePositions.

	(submorphs size > 0 and: [self indicateCursor]) ifTrue:
		[aCanvas
			frameRectangle: self selectedRect
			width: 2
			color: Color black].

