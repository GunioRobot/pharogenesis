applyResign: move
	"Give up."
	self userAgent ifNotNil:[
		self isWhitePlayer 
			ifTrue:[self userAgent finishedGame: 0]
			ifFalse:[self userAgent finishedGame: 1].
	].