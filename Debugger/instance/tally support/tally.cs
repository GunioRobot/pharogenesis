tally

	self getTextMorphWithSelection ifNotNilDo: [:o| o tallyIt] ifNil: [Beeper beep]
