reset
	super reset.
	origin _ 0@0.							"origin of the top-left corner of this cavas"
	clipRect _ (0@0 corner: 10000@10000).		"default clipping rectangle"
	currentTransformation _ nil.
	morphLevel _ 0.
	gstateStack _ OrderedCollection new.
	self initializeFontMap.
	usedFonts _ Set new.
     initialScale _ 1.0