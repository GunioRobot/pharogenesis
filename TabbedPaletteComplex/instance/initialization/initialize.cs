initialize
	super initialize.

	pageSize _ self defaultPageSize.
	self removeEverything.

	tabsMorph _ TabsMorph new.
	self addMorph: tabsMorph