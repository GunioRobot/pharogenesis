frameRect: rect borderWidth: borderWidth
	sourceX _ 0.
	sourceY _ 0.
	(rect areasOutside: (rect insetBy: borderWidth)) do:
		[:edgeStrip | self destRect: edgeStrip; copyBits].
