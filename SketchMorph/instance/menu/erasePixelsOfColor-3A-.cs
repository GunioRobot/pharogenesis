erasePixelsOfColor: evt

	| c r |
	c _ evt hand chooseColor.
	originalForm mapColor: c to: Color transparent.
	r _ originalForm rectangleEnclosingPixelsNotOfColor: Color transparent.
	self form: (originalForm copy: r).

