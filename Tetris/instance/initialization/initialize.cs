initialize

	super initialize.
	board _ TetrisBoard new game: self.
	color _ Color lightGray.
	self listDirection: #topToBottom.
	self wrapCentering: #center.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	self layoutInset: 3.
	self 
		addMorphBack: self makeGameControls;
		addMorphBack: self makeMovementControls;
		addMorphBack: self showScoreDisplay;
		addMorphBack: board.
	board newGame.

