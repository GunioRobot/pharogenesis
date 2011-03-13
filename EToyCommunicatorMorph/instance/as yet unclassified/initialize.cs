initialize

	super initialize.
	self vResizing: #shrinkWrap.
	self hResizing: #shrinkWrap.
	resultQueue _ SharedQueue new.
	fields _ Dictionary new.
	self useRoundedCorners.
