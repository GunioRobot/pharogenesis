initialize

	super initialize.
	board _ TetrisBoard new game: self.
	color _ Color lightGray.
	orientation _ #vertical.
	centering _ #center.
	vResizing _ #shrinkWrap.
	hResizing _ #spaceFill.
	inset _ 3.
	self 
		addMorphBack: self makeGameControls;
		addMorphBack: self makeMovementControls;
		addMorphBack: self showScoreDisplay;
		addMorphBack: board.
	board newGame.

