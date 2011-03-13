literal: anObject 
	literal := anObject.
	self updateLiteralLabel.
	self labelMorph
		ifNotNilDo: [:label | label informTarget]