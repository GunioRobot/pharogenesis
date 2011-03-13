chooseCollapsePoint
	"Answer the point at which to place the collapsed window."
	| pt labelForm beenDown offset |
	labelForm := Form fromDisplay: self labelDisplayBox.
	self uncacheBits.
	self erase.
	beenDown := Sensor anyButtonPressed.
	self isCollapsed ifTrue:
		[offset := self labelDisplayBox topLeft - self growBoxFrame topLeft.
		labelForm follow: [pt := (Sensor cursorPoint + offset max: 0@0) truncateTo: 8]
				while: [Sensor anyButtonPressed
							ifTrue: [beenDown := true]
							ifFalse: [beenDown not]].
		^ pt].
	^ (RealEstateAgent assignCollapseFrameFor: self) origin.
