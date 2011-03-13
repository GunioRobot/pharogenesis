changeWorldBoundsToShow: aRectangle

	aRectangle area = 0 ifTrue: [^self].
	worldBoundsToShow _ aRectangle.
	owner myWorldChanged.