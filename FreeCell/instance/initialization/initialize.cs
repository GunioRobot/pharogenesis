initialize

	super initialize.
	Statistics newSession.
	autoMoveRecursionCount _ 0.
	orientation _ #vertical.
	centering _ #center.
	vResizing _ #shrinkWrap.
	hResizing _ #shrinkWrap.
	self
		color: self colorNearTop;
		borderWidth: 2;
		addMorph: self makeControls;
		addMorph: self board;
		newGame.

