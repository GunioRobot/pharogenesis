noteNewOwner: win
	"Dirty fix for when the 'lower pane' hasn't been reset to the bottom at the
	time the receiver is added"

	super noteNewOwner: win.
	self setProperty: #browserWindow toValue: win.
	win ifNil: [ ^self ].
	win setProperty: #browserClassCommentPane toValue: self.
	self setProperty: #browserLowerPane toValue: (win submorphThat: [ :m | m isAlignmentMorph and: [ m layoutFrame bottomFraction = 1 or: [ m layoutFrame bottomFraction = self layoutFrame topFraction]]] ifNone: []).
