rule10
	"Rule 10: Shortening in clusters."
	| current next previous stream |
	phrase lastSyllable == syllable ifTrue: [^ self].
	stream _ ReadStream on: syllable events.
	current _ nil.
	next _ stream next.
	[stream atEnd]
		whileFalse: [previous _ current.
					current _ next.
					next _ stream next.
					current phoneme isVowel
						ifTrue: [next phoneme isVowel
									ifTrue: [current stretch: 1.2]
									ifFalse: [(previous notNil and: [previous phoneme isVowel])
												ifTrue: [current stretch: 0.7]]]
						ifFalse: [next phoneme isConsonant
									ifTrue: [(previous notNil and: [previous phoneme isConsonant])
												ifTrue: [current stretch: 0.5]
												ifFalse: [current stretch: 0.7]]
									ifFalse: [(previous notNil and: [previous phoneme isConsonant])
												ifTrue: [current stretch: 0.5]]]]