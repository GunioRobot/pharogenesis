mouseDownOnHelpHandle: anEvent
	"The mouse went down in the show-balloon handle"
	
	| str |
	anEvent shiftPressed ifTrue: [^ self editBalloonHelpText].
	str _ self balloonText.
	str ifNil: [str _ self noHelpString].
	self showBalloon: str hand: anEvent hand.
