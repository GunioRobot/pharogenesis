invert: aPoint
	^ globalTransform invert: (localTransform transform: aPoint)