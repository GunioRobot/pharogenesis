noteNewOwner: win
	super noteNewOwner: win.
	self setProperty: #browserWindow toValue: win.
	win ifNil: [ ^self ].
	win setProperty: #browserClassCommentPane toValue: self.
	self setProperty: #browserLowerPane toValue: (win submorphThat: [ :m | m isAlignmentMorph and: [ m layoutFrame bottomFraction = 1 ]] ifNone: []).
