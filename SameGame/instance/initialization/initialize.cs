initialize

	| |
	super initialize.
	orientation _ #vertical.
	centering _ #center.
	vResizing _ #shrinkWrap.
	hResizing _ #spaceFill.
	inset _ 3.
	color _ Color lightGray.
	self addMorph: self makeControls.
	self addMorph: self board.
	helpText _ nil.
	self newGame.