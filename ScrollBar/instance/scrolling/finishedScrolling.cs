finishedScrolling
	self stopStepping.
	self scrollBarAction: nil.
	self roundedScrollbarLook ifTrue:[
		upButton borderStyle: (BorderStyle complexRaised width: upButton borderWidth).
		downButton borderStyle: (BorderStyle complexRaised width: downButton borderWidth).
	] ifFalse:[
		downButton borderRaised.
		upButton borderRaised.
	].

