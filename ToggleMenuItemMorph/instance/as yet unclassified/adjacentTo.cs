adjacentTo
	"Adjusted to line up more nicely."
	
	self isInDockingBar
		ifFalse: [^{self bounds topRight + (5 @ 0). self bounds topLeft + (2@0)}].
	self owner isFloating
		ifTrue: [^ {self bounds bottomLeft + (4 @ 5)}].
	self owner isAdheringToTop
		ifTrue: [^ {self bounds bottomLeft + (5 @ 5)}].
	self owner isAdheringToLeft
		ifTrue: [^ {self bounds topRight + (5 @ 5)}].
	self owner isAdheringToBottom
		ifTrue: [^ {self bounds topLeft + (5 @ 5)}].
	self owner isAdheringToRight
		ifTrue: [^ {self bounds topLeft + (5 @ -5)}].
	^ {self bounds bottomLeft + (3 @ 5)}