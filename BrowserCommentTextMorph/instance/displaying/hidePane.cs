hidePane
	| win |
	self lowerPane ifNotNilDo: [ :lp | lp layoutFrame bottomFraction: self layoutFrame bottomFraction ].
	win _ self window ifNil: [ ^self ].
	self delete.
	win updatePanesFromSubmorphs.