allMenuWordings
	| tempMenu |
	tempMenu _ self currentHand buildMorphHandleMenuFor: self.
	tempMenu allMorphsDo: [:m | m step].  "Get wordings current"
	^ tempMenu allWordings