textStyled: s at: ignored0 font: ignored1 color: c justified: justify parwidth: parwidth

	self comment: ' text color: ',c printString.
	self setColor: c.
	self comment:'  origin ',  origin printString.
     "self moveto: point."		"now done by sender"
	target 
		print:' (';
		print: s asPostscript;
		print:') '.
	justify ifTrue: [
		target write: parwidth; print:' jshow'; cr.
	] ifFalse:[
		target print: 'show'.
	].
	target cr.

