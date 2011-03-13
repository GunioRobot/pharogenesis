finishedScrolling
	"Scrolling has finished (button or paging area)."
	
	|bcu bcd|
	bcu := upButton borderStyle baseColor.
	bcd := downButton borderStyle baseColor.
	self stopStepping.
	self scrollBarAction: nil.
	self roundedScrollbarLook
		ifTrue:[upButton borderStyle:
					(BorderStyle complexRaised width: upButton borderWidth; baseColor: bcu).
				downButton borderStyle:
					(BorderStyle complexRaised width: downButton borderWidth; baseColor: bcd)]
		ifFalse:[upButton borderRaised.
				upButton borderStyle baseColor: bcu.
				downButton borderRaised.
				downButton borderStyle baseColor: bcd].
	Preferences gradientScrollbarLook ifFalse: [^self].
	pagingArea
		fillStyle: self normalFillStyle;
		borderStyle: self normalBorderStyle