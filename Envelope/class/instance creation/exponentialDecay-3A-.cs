exponentialDecay: multiplier
	"(Envelope exponentialDecay: 0.95) "

	| mSecsPerStep pList t v last |
	mSecsPerStep _ 10.
	((multiplier > 0.0) and: [multiplier < 1.0])
		ifFalse: [self error: 'multiplier must be greater than 0.0 and less than 1.0'].
	pList _ OrderedCollection new.
	pList add: 0@0.0.
	last _ 0.0.
	v _ 1.0.
	t _ 10.
	[v > 0.01] whileTrue: [
		(v - last) abs > 0.02 ifTrue: [
			"only record substatial changes"
			pList add: t@v.
			last _ v].
		t _ t + mSecsPerStep.
		v _ v * multiplier].
	pList add: (t + mSecsPerStep)@0.0.

	^ self points: pList asArray
		loopStart: pList size 
		loopEnd: pList size
