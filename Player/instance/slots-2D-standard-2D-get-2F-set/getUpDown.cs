getUpDown
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #upDown) ifTrue: [^ renderedMorph upDown].

	^ (self costumeNamed: #JoystickMorph) upDown