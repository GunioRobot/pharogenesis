getCursorFor: anEventOrHand

	| plainCursor |
	plainCursor _ (self get: #currentCursor for: anEventOrHand) ifNil: [
		self set: #currentCursor for: anEventOrHand to: palette plainCursor
	].
	^palette
		cursorFor: (self getActionFor: anEventOrHand) 
		oldCursor: plainCursor 
		currentNib: (self getNibFor: anEventOrHand) 
		color: (self getColorFor: anEventOrHand)

