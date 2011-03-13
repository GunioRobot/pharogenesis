mouseLeaveThumb: event
	"The mouse has left the thumb."
	
	slider
		fillStyle: self normalThumbFillStyle;
		borderStyle: self normalThumbBorderStyle;
		changed.
	menuButton ifNotNil: [
		(self containsPoint: event position)
			ifTrue: [menuButton
					fillStyle: self mouseOverPagingAreaButtonFillStyle;
					borderStyle: self mouseOverPagingAreaButtonBorderStyle]
			ifFalse: [menuButton
					fillStyle: self normalButtonFillStyle;
					borderStyle: self normalButtonBorderStyle]].
	(self containsPoint: event position)
		ifTrue: [upButton
				fillStyle: self mouseOverPagingAreaButtonFillStyle;
				borderStyle: self mouseOverPagingAreaButtonBorderStyle]
		ifFalse: [upButton
				fillStyle: self normalButtonFillStyle;
				borderStyle: self normalButtonBorderStyle].
	(self containsPoint: event position)
		ifTrue: [downButton
				fillStyle: self mouseOverPagingAreaButtonFillStyle;
				borderStyle: self mouseOverPagingAreaButtonBorderStyle]
		ifFalse: [downButton
				fillStyle: self normalButtonFillStyle;
				borderStyle: self normalButtonBorderStyle]