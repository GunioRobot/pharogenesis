showPane
	owner ifNil: [
		| win |
		win _ self window ifNil: [ ^self ].
		win addMorph: self fullFrame: self layoutFrame.
		win updatePanesFromSubmorphs ].

	self lowerPane ifNotNilDo: [ :lp | lp layoutFrame bottomFraction: self layoutFrame topFraction ]