initialize
	super initialize.

	pageSize _ self defaultPageSize.
	self removeEverything.
	color _ Color transparent.
	borderWidth _ 0.
	tabsMorph _ IndexTabs new.
	self addMorph: tabsMorph