breakColumnAndResizeWithButtons: buttonRow
	| indexToSplit yToSplit |
	"The column of clues has been laid out, and the crostic panel has been resized to that width and embedded as a submorph.  This method breaks the clues in two, placing the long part to the left of the crostic and the short one below it."

	yToSplit _ cluesPanel height + quotePanel height // 2 + self top.
	indexToSplit _ cluesPanel submorphs findFirst: [:m | m bottom > yToSplit].
	cluesCol2 _ AlignmentMorph newColumn color: self color;
		hResizing: #shrinkWrap; vResizing: #shrinkWrap; layoutInset: 0;
		cellPositioning: #topLeft.
	cluesCol2 addAllMorphs: (cluesPanel submorphs copyFrom: indexToSplit + 1
							to: cluesPanel submorphs size).
	cluesPanel position: self position + self borderWidth + (0 @ 4).
	quotePanel position: self position + (quotePanel width @ 0).
	cluesCol2 position: self position + quotePanel extent + (0 @ 4).
	self addMorph: cluesCol2.
	self addMorph: buttonRow.
	buttonRow align: buttonRow topLeft with: cluesCol2 bottomLeft.
	self extent: 100@100; bounds: ((self fullBounds topLeft - self borderWidth asPoint)
							corner: (self fullBounds bottomRight - (2@0))).
