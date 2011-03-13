defineFactoryView

	| r |
	r _ Rectangle fromUser.
	self 
		setProperty: #factoryViewBounds 
		toValue: ((self transformFromOutermostWorld) globalBoundsToLocal: r) truncated 