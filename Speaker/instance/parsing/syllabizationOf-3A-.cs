syllabizationOf: phonemes
	| syllable stream last answer |
	answer _ OrderedCollection new.
	syllable _ Syllable new phonemes: (OrderedCollection new: 4).
	stream _ ReadStream on: phonemes.
	[stream atEnd]
		whileFalse: [syllable phonemes add: (last _ stream next).
					(stream atEnd not and: [last isConsonant not and: [stream peek isConsonant]])
						ifTrue: [answer add: syllable. syllable _ Syllable new phonemes: (OrderedCollection new: 4)]].
	syllable phonemes isEmpty ifFalse: [answer add: syllable].
	^ answer