text: s at:point font: fontOrNil color: c justified:justify
	self setFont:(fontOrNil ifNil:[self defaultFont]).
	self comment:' text color: ',c printString.
	self setColor:c.
	self comment:'  origin ',  origin printString.
     self moveto: point.
	target print:' (';
     	 print:s asPostscript;
		print:(justify ifTrue:[') jshow'] ifFalse:[') show']);
		 cr.
