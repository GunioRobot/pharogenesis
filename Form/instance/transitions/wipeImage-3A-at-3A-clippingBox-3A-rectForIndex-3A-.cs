wipeImage: otherImage at: topLeft clippingBox: clipBox rectForIndex: rectForIndexBlock

	| i clipRect t rectOrList waitTime |
	i _ 0.
	clipRect _ topLeft extent: otherImage extent.
	clipBox ifNotNil: [clipRect _ clipRect intersect: clipBox].
	[rectOrList _ rectForIndexBlock value: (i _ i + 1).
	 rectOrList == nil]
		whileFalse: [
			t _ Time millisecondClockValue.
			rectOrList asOrderedCollection do: [:r |
				self copyBits: r from: otherImage at: topLeft + r topLeft
					clippingBox: clipRect rule: Form over fillColor: nil].
			Display forceDisplayUpdate.
			waitTime _ 3 - (Time millisecondClockValue - t).
			waitTime > 0 ifTrue:
				["(Delay forMilliseconds: waitTime) wait"]].
