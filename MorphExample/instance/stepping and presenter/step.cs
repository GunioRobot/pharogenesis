step
	phase _ phase\\8 + 1.
	phase = 1 ifTrue: [^ ball delete].
	phase < 4 ifTrue:[^self].
	phase = 4 ifTrue: [self addMorph: ball].
	ball align: ball center with: (star vertices at: (phase-3*2)).