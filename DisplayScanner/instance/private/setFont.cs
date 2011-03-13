setFont 
	foregroundColor _ paragraphColor.
	super setFont.  "Sets font and emphasis bits, and maybe foregroundColor"
	font installOn: bitBlt foregroundColor: foregroundColor backgroundColor: Color transparent.
	text ifNotNil:[destY _ lineY + line baseline - font ascent]