= aLineStyle
	self class = aLineStyle class ifFalse:[^false].
	^self color = aLineStyle color and:[self width = aLineStyle width].