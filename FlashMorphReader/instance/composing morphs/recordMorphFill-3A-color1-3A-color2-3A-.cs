recordMorphFill: id color1: color1 color2: color2
	self recordSolidFill: id color: color2.
	morphedFillStyles at: id put: (fillStyles at: id).
	self recordSolidFill: id color: color1.