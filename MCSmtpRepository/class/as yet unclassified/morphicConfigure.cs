morphicConfigure
	| address |
	address := FillInTheBlankMorph request: 'Email address:'.
	^ address isEmpty ifFalse: [self new emailAddress: address]