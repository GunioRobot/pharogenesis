initialize
	super initialize.
	self cellPositioning: #topLeft.
	self reverseTableCells: true.
	self layout: #grid.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	borderWidth _ 0.
	self layoutInset: 0.
	stackingPolicy _ #stagger.
	stackingOrder _ #ascending.
	emptyDropPolicy _ #any.
	self newSeed.
	^self