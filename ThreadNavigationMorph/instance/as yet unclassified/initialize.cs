initialize

	super initialize.
	self useRoundedCorners.
	self layoutInset: 6.
	color _ self initialColor.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.
	self ensureSuitableDefaults.

	self addButtons.
