initialize
	super initialize.
	scrollDelta := 0.02.
	pageDelta := 0.2.
	self roundedScrollbarLook ifTrue:[
		self borderStyle: ((BorderStyle complexFramed width: 2) "baseColor: Color gray")].