hidePane
	| win |
	self window ifNotNilDo: [:window | window removePaneSplitters].
	
	self lowerPane ifNotNilDo:
		[ :lp | 
		lp layoutFrame bottomFraction: self layoutFrame bottomFraction.
		lp layoutFrame bottomOffset: SystemWindow borderWidth negated].
	win := self window ifNil: [ ^self ].
	self delete.
	win updatePanesFromSubmorphs.
	win addPaneSplitters