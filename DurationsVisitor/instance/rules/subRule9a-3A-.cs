subRule9a: aPhoneme
	"Sub-rule 9a, independent of segment position."
	aPhoneme isVoiced ifFalse: [^ aPhoneme isStop ifTrue: [0.7] ifFalse: [1.0]].
	aPhoneme isFricative ifTrue: [^ 1.6].
	aPhoneme isStop ifTrue: [^ 1.2].
	aPhoneme isNasal ifTrue: [^ 0.85].
	^ 1.0