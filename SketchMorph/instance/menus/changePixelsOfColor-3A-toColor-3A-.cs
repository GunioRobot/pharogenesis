changePixelsOfColor: c toColor: newColor

	| r |
	originalForm mapColor: c to: newColor.
	r _ originalForm rectangleEnclosingPixelsNotOfColor: Color transparent.
	self form: (originalForm copy: r).

