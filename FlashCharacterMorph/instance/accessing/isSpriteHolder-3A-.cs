isSpriteHolder: aBoolean
	aBoolean
		ifTrue:[self setProperty: #spriteHolder toValue: true]
		ifFalse:[self removeProperty: #spriteHolder]