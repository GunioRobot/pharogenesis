selectFrom: start to: stop
	"Deselect, then select the specified characters inclusive.
	 Be sure the selection is in view."

	(start = self startIndex and: [stop + 1 = self stopIndex]) ifFalse:
		[self deselect.
		self selectInvisiblyFrom: start to: stop].
	self selectAndScroll