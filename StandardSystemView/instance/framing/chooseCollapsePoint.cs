chooseCollapsePoint
	"Answer the point at which to place the collapsed window."
	| pt labelForm beenDown offset |
	labelForm _ Form fromDisplay: self labelDisplayBox.
	self uncacheBits.
	self erase.
	beenDown _ Sensor anyButtonPressed.
	self isCollapsed ifTrue:
		[offset _ self labelDisplayBox topLeft - self growBoxFrame topLeft.
		labelForm follow: [pt _ (Sensor cursorPoint + offset max: 0@0) truncateTo: 8]
				while: [Sensor anyButtonPressed
							ifTrue: [beenDown _ true]
							ifFalse: [beenDown not]].
		^ pt].
	^ (RealEstateAgent assignCollapseFrameFor: self) origin.
