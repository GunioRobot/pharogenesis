setCenter: aPoint
	aPoint == nil
		ifTrue:[self removeProperty: #center]
		ifFalse:[self setProperty: #center toValue: aPoint].