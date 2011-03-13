initialize

	super initialize.
	Statistics newSession.
	autoMoveRecursionCount _ 0.
	self listDirection: #topToBottom.
	self wrapCentering: #center; cellPositioning: #topCenter.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	self
		color: self colorNearTop;
		borderWidth: 2;
		addMorph: self makeControls;
		addMorph: self board;
		newGame.

