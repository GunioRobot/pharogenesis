rotateBoard
	self listDirection = #leftToRight
		ifTrue:[^self listDirection: #topToBottom; wrapDirection: #leftToRight].
	self listDirection = #topToBottom
		ifTrue:[^self listDirection: #rightToLeft; wrapDirection: #topToBottom].
	self listDirection = #rightToLeft
		ifTrue:[^self listDirection: #bottomToTop; wrapDirection: #rightToLeft].
	self listDirection = #bottomToTop
		ifTrue:[^self listDirection: #leftToRight; wrapDirection: #bottomToTop].
