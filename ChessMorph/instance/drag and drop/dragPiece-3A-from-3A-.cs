dragPiece: evt from: aMorph
	board searchAgent isThinking ifTrue:[^self].
	self submorphsDo:[:m| m borderWidth: 0].
	aMorph setProperty: #chessBoardSourceSquare toValue: (aMorph owner valueOfProperty: #squarePosition).
	evt hand grabMorph: aMorph.