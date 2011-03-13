mouseLeavePagingArea: event
	"The mouse has left the paging area."
	
	pagingArea
		fillStyle: self normalFillStyle;
		borderStyle: self normalBorderStyle;
		changed.
	slider
		fillStyle: self normalThumbFillStyle;
		borderStyle: self normalThumbBorderStyle;
		changed.
	menuButton ifNotNil: [
		menuButton
			fillStyle: self normalButtonFillStyle;
			borderStyle: self normalButtonBorderStyle;
			changed].
	upButton
		fillStyle: self normalButtonFillStyle;
		borderStyle: self normalButtonBorderStyle;
		changed.
	downButton
		fillStyle: self normalButtonFillStyle;
		borderStyle: self normalButtonBorderStyle;
		changed