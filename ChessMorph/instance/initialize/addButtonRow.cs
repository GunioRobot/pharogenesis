addButtonRow

	| r m |
	r _ AlignmentMorph newRow hResizing: #shrinkWrap; vResizing: #shrinkWrap; color: Color transparent.
	r addMorphBack: (self buttonName: '  New  ' action: #newGame).
	r addMorphBack: (self buttonName: '  Help  ' action: #findBestMove).
	r addMorphBack: (self buttonName: '  Play  ' action: #thinkAndMove).
	r addMorphBack: (self buttonName: '  Auto  ' action: #autoPlay).
	r addMorphBack: (self buttonName: '  Undo  ' action: #undoMove).
	r addMorphBack: (self buttonName: '  Redo  ' action: #redoMove).
	r addMorphBack: (self buttonName: '  Quit  ' action: #delete).
	r disableTableLayout: true.
	r align: r bounds topLeft with: self layoutBounds topLeft.
	self addMorphFront: r.
	m _ UpdatingStringMorph on: self selector: #statusString.
	m useStringFormat.
	m disableTableLayout: true.
	m align: m bounds topLeft with: r fullBounds bottomLeft.
	self addMorphFront: m.