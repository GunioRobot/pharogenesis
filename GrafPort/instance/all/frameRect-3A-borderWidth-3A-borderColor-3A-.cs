frameRect: rect borderWidth: borderWidth borderColor: borderColor

	sourceForm _ nil.
	self fillColor: borderColor.
	(rect areasOutside: (rect insetBy: borderWidth)) do:
		[:edgeStrip | self destRect: edgeStrip; copyBits].
