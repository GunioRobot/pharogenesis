text: s at:point font: fontOrNil color: c spacePad:pad
	self setFont:(fontOrNil ifNil:[self defaultFont]).
	self comment:' text color: ',c printString.
	self setColor:c.
	self comment:'  origin ',  origin printString.
     self moveto: point.
	
	target write:pad; print:' 0 32 (';
     	 print:s asPostscript; print:') widthshow'; cr.
