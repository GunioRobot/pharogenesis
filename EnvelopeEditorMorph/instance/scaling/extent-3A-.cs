extent: newExtent
	super extent: (newExtent max: (self maxTime//10*3+50 max: 200) @ 200).
	self buildView