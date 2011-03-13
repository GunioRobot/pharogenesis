initialize

	super initialize.
	self wrapCentering: #center; cellPositioning: #leftCenter.
	self hResizing: #shrinkWrap.
	borderWidth _ 0.
	self layoutInset: 0.
	self extent: 5@5.  "will grow to fit"
