getAmount
	| renderedMorph |
	((renderedMorph _ costume renderedMorph) respondsTo: #amount) ifTrue: [^ renderedMorph amount].
	^ (self costumeNamed: #JoystickMorph) amount