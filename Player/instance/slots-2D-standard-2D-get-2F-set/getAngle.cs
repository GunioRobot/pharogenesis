getAngle
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #angle) ifTrue: [^ renderedMorph angle].

	^ (self costumeNamed: #JoystickMorph) angle