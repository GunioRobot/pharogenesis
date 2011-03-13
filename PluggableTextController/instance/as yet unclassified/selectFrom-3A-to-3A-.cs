selectFrom: start to: stop
	"Deselect, then select the specified characters inclusive.
	 Be sure the selection is in view."

	(start = startBlock stringIndex and: [stop + 1 = stopBlock stringIndex]) ifFalse:
		[view superView ifNotNil: [self deselect].
		self selectInvisiblyFrom: start to: stop].
	view superView ifNotNil: [self selectAndScroll]