initialize
	super initialize.
	layout _ #grid.
	hResizing _ #shrinkWrap.
	vResizing _ #shrinkWrap.
	borderWidth _ 0.
	inset _ 0.
	stackingPolicy _ #stagger.
	stackingOrder _ #ascending.
	emptyDropPolicy _ #any.
	self newSeed.
	^self