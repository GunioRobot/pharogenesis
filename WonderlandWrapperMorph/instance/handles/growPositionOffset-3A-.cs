growPositionOffset: aPoint
	aPoint == nil
		ifTrue:[self removeProperty: #growPositionOffset]
		ifFalse:[self setProperty: #growPositionOffset toValue: aPoint].