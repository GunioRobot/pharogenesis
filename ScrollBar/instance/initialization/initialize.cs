initialize
	super initialize.
	scrollDelta _ 0.02.
	pageDelta _ 0.2.
	self roundedScrollbarLook ifTrue:[
		self borderStyle: ((BorderStyle complexFramed width: 2) "baseColor: Color gray")].