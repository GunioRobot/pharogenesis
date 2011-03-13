initialize

	super initialize.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	color _ Color paleYellow.
	borderWidth _ 8.
	borderColor _ color darker.
	self layoutInset: 4.
	self useRoundedCorners.
	printSpecs ifNil: [printSpecs _ PrintSpecifications defaultSpecs].
	self rebuild.
