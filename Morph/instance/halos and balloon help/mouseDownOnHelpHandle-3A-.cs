mouseDownOnHelpHandle: anEvent
	"The mouse went down in the show-balloon handle"
	
	| str |
	str _ self balloonText.
	str ifNil: [str _ self noHelpString].
	anEvent shiftPressed
		ifTrue: [self editBalloonHelpContent: str]
		ifFalse: [self showBalloon: str].
