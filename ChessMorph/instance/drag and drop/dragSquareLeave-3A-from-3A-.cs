dragSquareLeave: evt from: aMorph
	board ifNil:[^self].
	evt hand hasSubmorphs ifFalse:[^self].
	aMorph borderWidth: 0.