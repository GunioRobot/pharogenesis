initialize

	super initialize.
	self useRoundedCorners.
	self layoutInset: 6.
	color _ Color orange.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	mouseInside _ false.

	self addButtons.
