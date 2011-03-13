defineApplicationView

	| r |
	r _ Rectangle fromUser.
	self 
		setProperty: #applicationViewBounds 
		toValue: ((self transformFromOutermostWorld) globalBoundsToLocal: r) truncated 