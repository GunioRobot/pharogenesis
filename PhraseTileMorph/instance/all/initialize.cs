initialize

	super initialize.
	resultType = #unknown.
	brightenedOnEnter _ false.
	centering _ #center.
	hResizing _ #shrinkWrap.
	borderWidth _ 0.
	inset _ 0.
	self extent: 5@5.  "will grow to fit"
