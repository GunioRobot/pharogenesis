setFont 
	foregroundColor _ paragraphColor.
	super setFont.  "Sets font and emphasis bits, and maybe foregroundColor"
	font installOn: bitBlt foregroundColor: foregroundColor backgroundColor: Color transparent.
	text ifNotNil:[
		baselineY _ lineY + line baseline.
		destY _ baselineY - font ascent].
