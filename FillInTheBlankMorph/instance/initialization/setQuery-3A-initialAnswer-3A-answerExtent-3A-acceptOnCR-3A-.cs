setQuery: queryString initialAnswer: initialAnswer answerExtent: answerExtent acceptOnCR: acceptBoolean 
	| query topOffset accept cancel buttonAreaHeight |
	response := initialAnswer.
	done := false.
	self removeAllMorphs.
	self layoutPolicy: ProportionalLayout new.
	query := self createQueryTextMorph: queryString.
	topOffset := query height + 4.
	accept := self createAcceptButton.
	cancel := self createCancelButton.
	buttonAreaHeight := (accept height max: cancel height)
				+ 4.
	textPane := self
				createTextPaneExtent: answerExtent
				acceptBoolean: acceptBoolean
				topOffset: topOffset
				buttonAreaHeight: buttonAreaHeight.
	self extent: (query extent x max: answerExtent x)
			+ 4 @ (topOffset + answerExtent y + 4 + buttonAreaHeight).
	