selectFrom: start to: stop scroll: scrollCommand
	"Deselect, then select the specified characters inclusive.
	 Be sure the selection is in view."

	(start = self startIndex and: [stop + 1 = self stopIndex]) ifFalse:
		[view superView ifNotNil: [self deselect].
		self selectInvisiblyFrom: start to: stop].
	view superView ifNotNil: [self perform: scrollCommand]