erasePixelsOfColor: evt

	| c |
	c _ evt hand chooseColor.
	originalForm mapColor: c to: Color transparent.
	self form: (originalForm trimToPixelValue: Color transparent orNot: true).
