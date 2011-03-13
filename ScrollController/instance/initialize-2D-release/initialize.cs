initialize
	super initialize.
	scrollBar := Quadrangle new.
	scrollBar borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	marker := Quadrangle new.
	marker insideColor: Preferences scrollBarColor.
	menuBar := Quadrangle new.
	menuBar borderWidthLeft:  2 right: 0 top: 2 bottom: 2.