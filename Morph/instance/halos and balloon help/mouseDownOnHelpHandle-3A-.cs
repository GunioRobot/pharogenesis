mouseDownOnHelpHandle: anEvent
	"The mouse went down in the show-balloon handle"
	
	| str balloon |
	str _ self valueOfProperty: #balloonText.
	str ifNil: [str _ self noHelpString].
	anEvent controlKeyPressed ifTrue:
		[^ self editBalloonHelpContent: str].

	"Put up the actual balloon"
	balloon _ BalloonMorph string: str for: self corner: #topRight.
	"corner is a suggestion"
	self world addMorphFront: balloon.
	self setProperty: #balloon toValue: balloon