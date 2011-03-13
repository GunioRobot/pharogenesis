initializeScrollbar
	scrollBar _ OBScrollBar new model: self slotName: 'scrollBar'.
	scrollBar 
		borderWidth: 0;
		borderColor: #inset;
		height: self scrollBarHeight.
	self resizeScrollBar.
