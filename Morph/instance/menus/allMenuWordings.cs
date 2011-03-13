allMenuWordings
	| tempMenu |
	tempMenu _ self buildHandleMenu: self currentHand.
	tempMenu allMorphsDo: [:m | m step].  "Get wordings current"
	^ tempMenu allWordings