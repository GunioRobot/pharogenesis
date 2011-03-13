drawOn: aCanvas
	| area |
	super drawOn: aCanvas.
	
	barSize > 0 ifTrue: [
		area := self innerBounds.
		area := area origin extent: barSize-2@area extent y.
		aCanvas fillRectangle: area color: Preferences menuTitleColor.
	].
