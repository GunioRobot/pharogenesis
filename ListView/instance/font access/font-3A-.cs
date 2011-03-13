font: aFontOrNil

	aFontOrNil
		ifNil: [textStyle := nil]
		ifNotNil: [
			textStyle := TextStyle fontArray: (Array with: aFontOrNil).
			textStyle gridForFont: 1 withLead: 1].
	self changed: #list.  "update display"
