initialize

	super initialize.
	borderWidth _ 1.
	borderColor _ Color black.
	self layoutInset: 0.
	self hResizing: #shrinkWrap.
	self vResizing: #shrinkWrap.