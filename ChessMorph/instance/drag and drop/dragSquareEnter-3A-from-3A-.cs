dragSquareEnter: evt from: aMorph
	"Note: #wantsDroppedMorph: will validate move"
	board ifNil:[^self].
	evt hand hasSubmorphs ifFalse:[^self].
	(self wantsDroppedMorph: evt hand firstSubmorph event: evt) ifFalse:[^self].
	aMorph borderWidth: 1.