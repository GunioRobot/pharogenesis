initialize
	super initialize.
	scrollBar _ Quadrangle new.
	scrollBar borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	marker _ Quadrangle new.
	marker insideColor: Color gray.
	menuBar _ Quadrangle new.
	menuBar borderWidthLeft:  2 right: 0 top: 2 bottom: 2.