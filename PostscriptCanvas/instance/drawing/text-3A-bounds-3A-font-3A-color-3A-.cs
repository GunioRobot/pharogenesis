text: s bounds: boundsRect font: fontOrNil color: c 
	self setFont:(fontOrNil ifNil:[self defaultFont]).
	self comment:' text color: ',c printString.
	self setColor:c.
	self comment:' boundsrect origin ', boundsRect origin printString.
	self comment:'  origin ',  origin printString.
     self moveto: (boundsRect origin ).
	target print:' (';
     	 print:s asPostscript;
		print:') show';
		 cr.
