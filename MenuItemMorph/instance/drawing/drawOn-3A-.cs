drawOn: aCanvas

	(isSelected & isEnabled) ifTrue: [
		aCanvas fillRectangle: self bounds color: owner color darker].
	super drawOn: aCanvas.
	subMenu == nil ifFalse: [
		aCanvas
			image: SubMenuMarker
			at: (self right - 8 @ ((self top + self bottom - SubMenuMarker height) // 2))].
