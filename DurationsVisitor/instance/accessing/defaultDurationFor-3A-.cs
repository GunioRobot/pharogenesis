defaultDurationFor: aPhoneme
	"Some hardcoded durations for phonemes."
	aPhoneme isVoiced ifTrue: [^ 0.0565].
	aPhoneme isUnvoiced ifTrue: [^ 0.0751].
	aPhoneme isConsonant ifTrue: [^ 0.06508].
	aPhoneme isDiphthong ifTrue: [^ 0.1362].
	^ 0.0741