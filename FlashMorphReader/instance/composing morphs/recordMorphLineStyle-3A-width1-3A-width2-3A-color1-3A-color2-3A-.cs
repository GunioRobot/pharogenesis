recordMorphLineStyle: id width1: lineWidth1 width2: lineWidth2 color1: lineColor1 color2: lineColor2
	self recordLineStyle: id width: lineWidth2 color: lineColor2.
	morphedLineStyles at: id put: (lineStyles at: id).
	self recordLineStyle: id width: lineWidth1 color: lineColor1.