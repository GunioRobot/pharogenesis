syllabizationOf: phonemes
	| syllable stream last answer |
	answer := OrderedCollection new.
	syllable := Syllable new phonemes: (OrderedCollection new: 4).
	stream := ReadStream on: phonemes.
	[stream atEnd]
		whileFalse: [syllable phonemes add: (last := stream next).
					(stream atEnd not and: [last isConsonant not and: [stream peek isConsonant]])
						ifTrue: [answer add: syllable. syllable := Syllable new phonemes: (OrderedCollection new: 4)]].
	syllable phonemes isEmpty ifFalse: [answer add: syllable].
	^ answer