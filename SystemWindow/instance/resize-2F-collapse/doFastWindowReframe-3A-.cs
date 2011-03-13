doFastWindowReframe: ptName

	| newBounds |
	"For fast display, only higlight the rectangle during loop"
	newBounds := self bounds newRectButtonPressedDo: [:f | 
		f 
			withSideOrCorner: ptName
			setToPoint: (self pointFromWorld: Sensor cursorPoint)
			minExtent: self minimumExtent].
	Display deferUpdatesIn: Display boundingBox while: [
		self bounds: newBounds].
	^newBounds.