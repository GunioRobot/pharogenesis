font: aFontOrNil

	aFontOrNil
		ifNil: [textStyle _ nil]
		ifNotNil: [
			textStyle _ TextStyle fontArray: (Array with: aFontOrNil).
			textStyle gridForFont: 1 withLead: 1].
	self changed: #list.  "update display"
