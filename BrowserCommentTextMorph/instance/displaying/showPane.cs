showPane
	owner ifNil: [
		| win |
		win := self window ifNil: [ ^self ].
		win addMorph: self fullFrame: self layoutFrame.
		win updatePanesFromSubmorphs ].

	self lowerPane ifNotNilDo: [ :lp | lp layoutFrame bottomFraction: self layoutFrame topFraction ].
	
	self window ifNotNilDo: [:win | win addPaneSplitters]