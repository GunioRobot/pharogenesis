clippedBy: aRectangle
	^ self copy clipRect: (self clipRect intersect: aRectangle)