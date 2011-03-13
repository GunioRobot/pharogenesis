doOneCycle

	pendingEvent ifNotNil: [
		self primaryHand handleEvent: (pendingEvent setHand: self primaryHand).
		pendingEvent _ nil.
	].
	^super doOneCycle.