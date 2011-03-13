chooseCollapsePoint
	"Answer the point at which to place the collapsed window."
	| p1 labelForm beenDown offset |
	labelForm _ Form fromDisplay: self labelDisplayBox.
	self uncacheBits.
	self erase.
	beenDown _ Sensor anyButtonPressed.
	self isCollapsed | collapsedViewport isNil
		ifTrue: [offset _ self labelDisplayBox topLeft - self growBoxFrame topLeft.
				labelForm follow: [p1 _ (Sensor cursorPoint + offset max: 0@0) truncateTo: 8]
					while: [Sensor anyButtonPressed
								ifTrue: [beenDown _ true]
								ifFalse: [beenDown not]] ]
		ifFalse: [labelForm slideFrom: self labelDisplayBox origin
					to: collapsedViewport origin nSteps: 10.
				p1 _ collapsedViewport topLeft].
	^ p1