editBalloonHelpText
	| str  |
	str _ self valueOfProperty: #balloonText.
	str ifNil: [str _ self noHelpString].
	self editBalloonHelpContent: str