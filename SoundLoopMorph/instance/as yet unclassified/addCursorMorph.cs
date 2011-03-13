addCursorMorph
	self addMorph:
		(cursor _ (RectangleMorph
				newBounds: (self innerBounds topLeft extent: 1@self innerBounds height)
				color: Color red)
						borderWidth: 0)