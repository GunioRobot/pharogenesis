fullDrawOn: aCanvas

	| mask |
	(aCanvas isVisible: self fullBounds) ifFalse:[^self].
	super fullDrawOn: aCanvas.
	mask _ self valueOfProperty: #disabledMaskColor ifAbsent: [^self].
	aCanvas fillRectangle: bounds color: mask.
