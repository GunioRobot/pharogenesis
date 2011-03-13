selectFrom: start to: stop
	"Deselect, then select the specified characters inclusive.
	 Be sure the selection is in view."

	(start = startBlock stringIndex and: [stop + 1 = stopBlock stringIndex]) ifFalse:
		[self deselect.
		self selectInvisiblyFrom: start to: stop].
	self selectAndScroll