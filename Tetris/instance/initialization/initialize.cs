initialize
	"initialize the state of the receiver"
	super initialize.
	""
	board _ TetrisBoard new game: self.
	self listDirection: #topToBottom;
	  wrapCentering: #center;
	  vResizing: #shrinkWrap;
	  hResizing: #shrinkWrap;
	  layoutInset: 3;
	  addMorphBack: self makeGameControls;
		 addMorphBack: self makeMovementControls;
		 addMorphBack: self showScoreDisplay;
		 addMorphBack: board.
	board newGame