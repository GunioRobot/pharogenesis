dragPositionOffset: aPoint
	aPoint == nil
		ifTrue:[self removeProperty: #dragPositionOffset]
		ifFalse:[self setProperty: #dragPositionOffset toValue: aPoint].