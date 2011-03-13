adoptPaneColor: aColor

	super adoptPaneColor: aColor.
	Preferences gradientButtonLook ifFalse:[^self].
	aColor ifNil: [^self].
	self adoptColor: self colorToUse