mouseMovedFrom: beginBlock pivotBlock: pivotBlock showingCaret: caretOn 
	| startBlock stopBlock showingCaret |
	stopBlock _ startBlock _ beginBlock.
	showingCaret _ caretOn.
	[Sensor redButtonPressed]
		whileTrue: 
			[stopBlock _ self characterBlockAtPoint: Sensor cursorPoint.
			stopBlock = startBlock
				ifFalse: 
					[showingCaret
						ifTrue: 
							[showingCaret _ false.
							self reverseFrom: pivotBlock to: pivotBlock].
			((startBlock >= pivotBlock and: [stopBlock >= pivotBlock])
				or: [startBlock <= pivotBlock and: [stopBlock <= pivotBlock]])
				ifTrue: 
					[self reverseFrom: startBlock to: stopBlock.
					startBlock _ stopBlock]
				ifFalse: 
					[self reverseFrom: startBlock to: pivotBlock.
					self reverseFrom: pivotBlock to: stopBlock.
					startBlock _ stopBlock].
			(clippingRectangle contains: stopBlock) ifFalse:
				[stopBlock top < clippingRectangle top
				ifTrue: [self scrollBy: stopBlock top - clippingRectangle top
						withSelectionFrom: pivotBlock to: stopBlock]
				ifFalse: [self scrollBy: stopBlock bottom + textStyle lineGrid - clippingRectangle bottom
						withSelectionFrom: pivotBlock to: stopBlock]]]].
	pivotBlock = stopBlock ifTrue:
		[showingCaret ifFalse:  "restore caret"
			[self reverseFrom: pivotBlock to: pivotBlock]].
	^ Array with: pivotBlock with: stopBlock