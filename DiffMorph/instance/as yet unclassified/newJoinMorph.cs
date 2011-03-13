newJoinMorph
	"Answer a new join morph."

	^DiffJoinMorph new
		hResizing: #shrinkWrap;
		vResizing: #spaceFill;
		extent: 30@4;
		minWidth: 30;
		color: self joinColor