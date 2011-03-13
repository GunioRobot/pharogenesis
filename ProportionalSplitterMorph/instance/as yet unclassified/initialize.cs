initialize

	super initialize.
	
	self hResizing: #spaceFill.
	self vResizing: #spaceFill.
	splitsTopAndBottom _ false.
	
	leftOrTop _ OrderedCollection new.
	rightOrBottom _ OrderedCollection new