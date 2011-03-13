getLeftRight
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #leftRight) ifTrue: [^ renderedMorph leftRight].

	^ (self costumeNamed: #JoystickMorph) leftRight