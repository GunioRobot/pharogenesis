debugDrawRectsOn: aCanvas
	bounds == nil ifTrue:[^self].
	bounds keysAndValuesDo:[:actor :rect|
		aCanvas frameRectangle: rect color: Color white.
	].